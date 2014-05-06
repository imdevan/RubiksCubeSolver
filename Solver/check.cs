using System;
 
namespace Main_Method
{
  class check
   {
     float num, percent;
     public void accept()
      { 
        Console.Write("\nEnter your marks. (Total                   Mark = 850):\t");
        num = float.Parse(Console.ReadLine());
      }
     public void print()
      {        
        percent = (float)num / 850 * 100;
        if (percent < 35)
         {
           Console.WriteLine("Sorry!!! You are fail.                   your marks is "+percent);
         }
        else if (percent > 35 && percent < 50)
         {
           Console.WriteLine("You got grade D and                       your percentage marks is " + percent);
         }
        else if (percent > 50 && percent < 60)
         {
           Console.WriteLine("You got grade C and you                   percentage marks is " + percent);
         }
        else if (percent > 60 && percent < 75)
         {
           Console.WriteLine("You got grade B and your                 percentage marks is " + percent);
         }
        else
         {
           Console.WriteLine("You got grade A and your                 percentage marks is " + percent);
         }
      }
   }
 
  class Program
   {
     static void Main(string[] args)
      {
        // Starting execution
        // Creating object of class check
        check chk = new check();
        chk.accept(); //Invoking accept method
        chk.print(); //Invoking print method
        Console.ReadLine();
      }
   }
}