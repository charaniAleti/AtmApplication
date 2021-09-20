using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtmApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Program();
            a.AtmAmount();       
        }
        public Boolean Validation(long amount)
        {
            //The validation happens to check if there exists any amount in atm.
            if (amount <= 0)
            {
                Console.WriteLine("ATM_ERR");
                return false;
            }
            else
            {
                return true;
            }
        }
        public void AtmAmount()
        {            
            //code to read and validate the amount in ATM (first line of input).
            long atmAmount = Convert.ToInt64(Console.ReadLine());
            if (Validation(atmAmount) == true)
            {                
                Inputs(atmAmount);
            }
            else
            {
                //system doesn't allow the user to transactions section as there is no enough cash in machine.
                AtmAmount();
            }
        }
        public void Inputs(long amount)
        {
            long ATMBalance = amount;
            
            string input;
            while (true)
            {
                List<String> account = new List<string>();
                List<int> balance = new List<int>();

                while (!string.IsNullOrWhiteSpace(input = Console.ReadLine()))                
                {
                    List<String> line = new List<string>();
                    
                    Boolean flag = true;
                    
                    line = input.Split(' ').ToList();
                   
                    if (line.Count == 3)
                    {
                        account = line;
                        if (account[2] == account[1])
                        {
                            flag = true;
                        }
                        else
                        {
                            Console.WriteLine("ACCT_ERR");
                            flag = false;
                        }
                    }
                    else if (line.Count ==2)
                    {
                        if(line[0] == "W" || line[0] == "w")
                        {
                            Console.WriteLine("atm balance : "+ ATMBalance);

                            if((balance[0] + balance[1]) >= Int32.Parse(line[1]))
                            {
                                if (Int32.Parse(line[1]) > ATMBalance)
                                {
                                    Console.WriteLine("ATM_ERR");
                                }
                                else
                                {
                                    if(balance[0]<= Int32.Parse(line[1]))
                                    {
                                        balance[0] = 0;
                                        balance[1] = balance[1] - (Int32.Parse(line[1]) - balance[0]);       
                                    }
                                    else
                                    {
                                        balance[0] = balance[0] - Int32.Parse(line[1]);
                                    }

                                    ATMBalance = ATMBalance - Int32.Parse(line[1]);

                                    if (flag)
                                    {
                                        Console.WriteLine(balance[0]);
                                    }
                                    else
                                    {
                                        Console.WriteLine("ACCT_ERR");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("FUNDS_ERR");
                            }
                        }
                        else
                        {
                            balance.Add(Int32.Parse(line[0]));
                            balance.Add(Int32.Parse(line[1]));
                        }
                    }
                    else
                    {
                        Console.WriteLine(balance[0]);
                    }
                    
                    

                }
            }
            //}
            //else
            //{
            //    Inputs();
            //}
        }
    }
}
