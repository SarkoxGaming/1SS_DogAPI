using System;
using System.Collections.Generic;
using System.Text;

namespace ApiHelper
{
    public class BreedModel
    {

        public Dictionary<string, List<string>> Message { get; set; }
        
        public List<string> getAllBread()
        {
            List<string> temp = new List<string>();

            foreach (string breed in Message.Keys)
            {
                
                List<string> downs_breed;

                if (Message.TryGetValue(breed, out downs_breed))
                {
                    if (downs_breed.Count == 0)
                    {
                        temp.Add(string.Concat(breed[0].ToString().ToUpper(), breed.AsSpan(1)));
                    }
                    else
                    {
                        foreach (string down_breed in downs_breed)
                        {
                            temp.Add(string.Concat(breed[0].ToString().ToUpper(), breed.AsSpan(1)) + " " + string.Concat(down_breed[0].ToString().ToUpper(), down_breed.AsSpan(1)));
                        }
                    }
                }
                
            }

            return temp;
        }
       
    }
}
