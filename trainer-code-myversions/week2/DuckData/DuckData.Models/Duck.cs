namespace DuckData.Models
{
    public class Duck
    {
        //Fields and variables
        public int ID { get; set; }
        public string color { get; set; }
        public int numFeathers { get; set; }
        private int IDCounter = 0;

        //Constructors
        public Duck(int ID, string color, int feathers)
        {
            this.ID = ID;
            this.color = color;
            this.numFeathers = feathers;
        }

        public Duck(string color, int feathers)
        {
            this.color = color;
            this.numFeathers = feathers;
            this.ID = this.IDCounter;
            IDCounter++;
        }

        public Duck() { }

        //Methods
        public void Quack()
        {
            Console.WriteLine("Quack! I'm a " + color + " duck!");
        }

        //Returning the imporant values of a "Duck" in order to potentially save the data of this Duck for later use
        public string ToString()
        {
            string result = "";
            result = this.ID + " " + this.color + " " + this.numFeathers;
            //return ("{0}{1}", this.color, this.numFeathers);
            return result;
        }
    }
}