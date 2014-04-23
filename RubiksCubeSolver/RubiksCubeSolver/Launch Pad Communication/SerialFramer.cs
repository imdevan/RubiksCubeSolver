using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Serial
{
     class SerialFramer
     {
          // The two headers at the beginning of each message
          private const byte MESSAGE_HEADER1 = 0xC6;
          private const byte MESSAGE_HEADER2 = 0xA2;

          // State for decoding a raw message
          private enum FramerState
          {
               SearchHeader1,
               SearchHeader2,
               SearchLength,
               SearchData,
               SearchChecksum
          };

          // Holds the length of the payload in the message
          private byte _Length;
          // Holds the payload
          private List<byte> _Data;
          // Holds the state within the decoder state machine
          private FramerState _State;

          // Event for signaling a full message has been received
          public event SerialMessageReceived _SerialMessageRx;
          public delegate void SerialMessageReceived(object Obj, SerialMessageArgs Args);
          public class SerialMessageArgs : EventArgs
          {
               byte[] _Message;
               public SerialMessageArgs(byte[] Message)
               {
                    _Message = Message;
               }
               public byte[] Message
               {
                    get { return _Message; }
               }
          }
          // Constructor
          public SerialFramer()
          {
               // Set initial state of decode machine
               _State = FramerState.SearchHeader1;
          }

          ~SerialFramer()
          {

          }

          // Handles receiving data 
          public void SerialPortDataRxHandler(object Obj, Serial.RxEventData Args)
          {
               DecodeRxByte(Args.Data);
          }

          // State machine for decoding a message
          private void DecodeRxByte(byte Data)
          {
               switch (_State)
               {
                         // Check to see if first header matches
                    case FramerState.SearchHeader1:
                         if (Data == MESSAGE_HEADER1)
                         {
                              _State = FramerState.SearchHeader2;
                         }
                         break;

                         // Check to see if second header matches
                    case FramerState.SearchHeader2:
                         if (Data == MESSAGE_HEADER2)
                         {
                              _State = FramerState.SearchLength;
                         }
                         break;

                         // Record the length
                    case FramerState.SearchLength:
                         _Length = Data;
                         _Data = new List<byte>();
                         _State = FramerState.SearchData;
                         break;

                         // Collect Data for payload
                    case FramerState.SearchData:
                         if (_Length > 0)
                         {
                              _Data.Add(Data);
                              _Length--;
                              // If there is data left, stay in SearchData
                              // If all data has been collected, next byte will be the checksum
                              _State = (_Length > 0) ? FramerState.SearchData : FramerState.SearchChecksum;
                         }
                         break;
                         
                         // Calculate checksum
                    case FramerState.SearchChecksum:
                         {
                              byte checksum = 0;
                              // Add headers and length
                              checksum += MESSAGE_HEADER1;
                              checksum += MESSAGE_HEADER2;
                              checksum += (byte)(_Data.Count & 0xFF);

                              // Add the command and payload
                              for (int index = 0; index < _Data.Count; index++)
                              {
                                   checksum += _Data[index];
                              }
                              // Negate checksum
                              checksum = (byte)((~checksum) & (0xFF));
                              // Does the checksum match
                              if (checksum == Data)
                              {
                                   // Notify upper layer that a full message
                                   // has been received
                                   OnSerialMessageReceived(_Data);
                              }
                         }
                         break;
               }
          }

          // Generate event for full message received
          public void OnSerialMessageReceived(List<byte> Message)
          {
               if (_SerialMessageRx != null)
               {
                    _SerialMessageRx(this, new SerialMessageArgs(Message.ToArray()));     
               }
          }

          // Checksum calculation
          public byte CalcChecksum(byte[] Message)
          {
               byte checksum = 0;
               // sum all bytes received
               foreach (byte b in Message)
               {
                    checksum += b;
               }
               // negate sum
               checksum = (byte) ((~checksum) & (0xFF));
               return checksum;
          }

          // Create a framed message
          public byte[] FrameMessage(byte[] Message)
          {
               // Make a list to hold message
               List<byte> message = new List<byte>();
               // Add headers
               message.Add(MESSAGE_HEADER1);
               message.Add(MESSAGE_HEADER2);
               // Add length
               message.Add((byte)Message.Length);
               // Add the payload
               foreach (byte b in Message)
               {
                    message.Add(b);
               }
               // Add checksum
               message.Add(CalcChecksum(message.ToArray()));
               // return framed message
               return message.ToArray();
          }
     }
}
