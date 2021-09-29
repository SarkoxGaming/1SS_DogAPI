using System;
using System.Collections.Generic;
using System.Text;

namespace ApiHelper
{
    public class DogModel
    {
        private bool affiche = false;
        private int minDog;

        public int MinDog
        {
            get { return minDog; }
            set { minDog = value;}
        }

        private int maxDog;

        public int MaxDog
        {
            get { return maxDog; }
            set { maxDog = value; }
        }

        public int ConstMax { get; set; }


        private List<string> message;
        public List<string> Message { 
            get {
                if (!affiche)
                    return message;
                else
                {
                    return message.GetRange(MinDog, MinDog + ConstMax > message.Count? message.Count : ConstMax);
                }
                    
            }
            set { 
                message = value;
            }
        }



        public void display()
        {
            affiche = true;
        }

        

        public bool next()
        {
            MinDog+=ConstMax;
            if (MinDog + ConstMax > message.Count)
            {
                MinDog = message.Count - ConstMax;
                return false;
            }
            return true;
        }

        public bool previous()
        {
            MinDog -= ConstMax;
            if (MinDog < 0)
            {
                MinDog = 0;
                return false;
            }
            return true;
        }


        public string Url { get; set; }
    }
}
