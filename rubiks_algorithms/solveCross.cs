//solveCross algo.

        public static void solveCross()
        {
            if ((upper[0, 1] == (int)Color.red) && (upper[1, 0] == (int)Color.red) && (upper[2, 1] == (int)Color.red) && (upper[1, 2] == (int)Color.red))
            {
                phase = (int)Phase.second;
                Console.Write("PHASE II");
                Console.WriteLine();
            }
            else if ((upper[0, 1] != (int)Color.red) || (upper[1, 0] != (int)Color.red) || (upper[2, 1] != (int)Color.red) || (upper[1, 2] != (int)Color.red))
            {
                if ((down[0, 1] == (int)Color.red) || (down[1, 0] == (int)Color.red) || (down[2, 1] == (int)Color.red) || (down[1, 2] == (int)Color.red))
                {

                    if (down[0, 1] == (int)Color.red)   //handles front
                    {
                        if (upper[2, 1] != (int)Color.red)
                        {
                            move = "F";
                            movement(move);
                            MoveSet.Add(move);
                            movement(move);
                            MoveSet.Add(move);
                        }
                        else
                        {
                            move = "D";
                            movement(move);
                            MoveSet.Add(move);
                        }
                    }
                    else if (down[1, 0] == (int)Color.red)  //handles left
                    {
                        if (upper[1, 0] != (int)Color.red)
                        {
                            move = "L";
                            movement(move);
                            MoveSet.Add(move);
                            movement(move);
                            MoveSet.Add(move);
                        }
                        else
                        {
                            move = "D";
                            movement(move);
                            MoveSet.Add(move);
                        }
                    }
                    else if (down[2, 1] == (int)Color.red)  //handles back
                    {
                        if (upper[0, 1] != (int)Color.red)
                        {
                            move = "B";
                            movement(move);
                            MoveSet.Add(move);
                            movement(move);
                            MoveSet.Add(move);
                        }
                        else
                        {
                            move = "D";
                            movement(move);
                            MoveSet.Add(move);
                        }
                    }
                    else if (down[1, 2] == (int)Color.red)  //handles right
                    {
                        if (upper[1, 2] != (int)Color.red)
                        {
                            move = "R";
                            movement(move);
                            MoveSet.Add(move);
                            movement(move);
                            MoveSet.Add(move);
                        }
                        else
                        {
                            move = "D";
                            movement(move);
                            MoveSet.Add(move);
                        }
                    }

                }
              /*initial BREAK*/  else if ((down[0, 1] != (int)Color.red) && (down[1, 0] != (int)Color.red) && (down[2, 1] != (int)Color.red) && (down[1, 2] != (int)Color.red))
                {
                    if((left[0, 1] == (int)Color.red) || (left[1, 0] == (int)Color.red) || (left[2, 1] == (int)Color.red) || (left[1, 2] == (int)Color.red))
                {
                    if (left[0, 1] == (int)Color.red)
                    {
                        move = "l";
                        movement(move);
                        MoveSet.Add(move);
                        move = "U";
                        movement(move);
                        MoveSet.Add(move);
                        move = "b";
                        movement(move);
                        MoveSet.Add(move);
                        move = "u";
                        movement(move);
                        MoveSet.Add(move);
                      
                     
                    }else if(left[0, 1] != (int)Color.red){
                    /*else*/ if ((left[1, 0] == (int)Color.red))
                    {
                        if (upper[1, 0] == (int)Color.red)
                        {
                            move = "U";
                            movement(move);
                            MoveSet.Add(move);
                        }
                        else
                        {
                            move = "L";
                            movement(move);
                            MoveSet.Add(move);
                        }
                    }
                    else if ((left[2, 1] == (int)Color.red))
                    {
                        if (upper[1, 0] == (int)Color.red)
                        {
                            move = "U";
                            movement(move);
                            MoveSet.Add(move);
                        }
                        else
                        {
                            move = "L";
                            movement(move);
                            MoveSet.Add(move);
                            movement(move);
                            MoveSet.Add(move);
                        }
                    }
                    else if ((left[1, 2] == (int)Color.red))
                    {
                        if (upper[1, 0] == (int)Color.red)
                        {
                            move = "U";
                            movement(move);
                            MoveSet.Add(move);
                        }
                        else
                        {
                            move = "l";
                            movement(move);
                            MoveSet.Add(move);
                        }
                    }
                    }
                } else if ((front[0, 1] == (int)Color.red) || (front[1, 0] == (int)Color.red) || (front[2, 1] == (int)Color.red) || (front[1, 2] == (int)Color.red))
                    {
                        if (front[0, 1] == (int)Color.red)
                        {
                            move = "f";
                            movement(move);
                            MoveSet.Add(move);
                            move = "U";
                            movement(move);
                            MoveSet.Add(move);
                            move = "l";
                            movement(move);
                            MoveSet.Add(move);
                            move = "u";
                            movement(move);
                            MoveSet.Add(move);
                        }
                        else if (front[0, 1] != (int)Color.red)
                        {
                            if ((front[1, 0] == (int)Color.red))
                            {
                                if (upper[2, 1] == (int)Color.red)
                                {
                                    move = "U";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                                else
                                {
                                    move = "F";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                            }
                            else if ((front[2, 1] == (int)Color.red))
                            {
                                if (upper[2, 1] == (int)Color.red)
                                {
                                    move = "U";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                                else
                                {
                                    move = "F";
                                    movement(move);
                                    MoveSet.Add(move);
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                            }
                            else if ((front[1, 2] == (int)Color.red))
                            {
                                if (upper[2, 1] == (int)Color.red)
                                {
                                    move = "U";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                                else
                                {
                                    move = "f";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                            }
                        }
                    }
                    else if ((right[0, 1] == (int)Color.red) || (right[1, 0] == (int)Color.red) || (right[2, 1] == (int)Color.red) || (right[1, 2] == (int)Color.red))
                    {
                        if (right[0, 1] == (int)Color.red)
                        {
                            move = "r";
                            movement(move);
                            MoveSet.Add(move);
                            move = "U";
                            movement(move);
                            MoveSet.Add(move);
                            move = "f";
                            movement(move);
                            MoveSet.Add(move);
                            move = "u";
                            movement(move);
                            MoveSet.Add(move);
                        }
                        else if (right[0, 1] != (int)Color.red)
                        {
                            if ((right[1, 0] == (int)Color.red))
                            {
                                if (upper[1, 2] == (int)Color.red)
                                {
                                    move = "U";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                                else
                                {
                                    move = "R";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                            }
                            else if ((right[2, 1] == (int)Color.red))
                            {
                                if (upper[1, 2] == (int)Color.red)
                                {
                                    move = "U";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                                else
                                {
                                    move = "R";
                                    movement(move);
                                    MoveSet.Add(move);
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                            }
                            else if ((right[1, 2] == (int)Color.red))
                            {
                                if (upper[1, 2] == (int)Color.red)
                                {
                                    move = "U";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                                else
                                {
                                    move = "r";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                            }
                        }
                    }
                    else if ((back[0, 1] == (int)Color.red) || (back[1, 0] == (int)Color.red) || (back[2, 1] == (int)Color.red) || (back[1, 2] == (int)Color.red))
                    {
                        if (back[0, 1] == (int)Color.red)
                        {
                            move = "b";
                            movement(move);
                            MoveSet.Add(move);
                            move = "U";
                            movement(move);
                            MoveSet.Add(move);
                            move = "r";
                            movement(move);
                            MoveSet.Add(move);
                            move = "u";
                            movement(move);
                            MoveSet.Add(move);
                        }
                        else if (back[0, 1] != (int)Color.red)
                        {
                            if ((back[1, 0] == (int)Color.red))
                            {
                                if (upper[0, 1] == (int)Color.red)
                                {
                                    move = "U";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                                else
                                {
                                    move = "B";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                            }
                            else if ((back[2, 1] == (int)Color.red))
                            {
                                if (upper[0, 1] == (int)Color.red)
                                {
                                    move = "U";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                                else
                                {
                                    move = "B";
                                    movement(move);
                                    MoveSet.Add(move);
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                            }
                            else if ((back[1, 2] == (int)Color.red))
                            {
                                if (upper[0, 1] == (int)Color.red)
                                {
                                    move = "U";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                                else
                                {
                                    move = "b";
                                    movement(move);
                                    MoveSet.Add(move);
                                }
                            }
                        }
                    }			 
				 			 
				 			 
			

                }//HERE
            }
            else
            {
                phase = (int)Phase.first;
            }

        }
                    