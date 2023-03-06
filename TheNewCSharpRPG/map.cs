namespace RPGOne
    {
    public class Map
        {
        public string Name;

        public Map(string name)
            {
            Name = name;
            }

        public void Path()
            {
            //like a way pointer #TODO
            }

        public void MapAdd(string key,object value)
            {
            Dictionary<string,object> map = new Dictionary<string,object>();
            map.Add(key,value);
            Console.WriteLine(map);
            }

        public void Plan()
            {
            Console.WriteLine("" +
              "\n||||||||||||||||||\n" +
                "||||||none |||||||\n" +
                "|none|orc  |none |\n" +
                "|none|peon |store|\n" +
                "|none|start|rat  |\n" +
                "|none|gem  |none |\n" +
                "||||||none |||||||\n" +
                "||||||||||||||||||");
            //should learn how to make a cli table for proper show of that map
            }
        }
    }