using static System.Console;

namespace RPGOne
    {
    /// <summary>
    /// Every RPG needs a map!
    /// </summary>
    public class Map
        {
        public string name { get; set; }


        /// <summary>
        /// Constructor for an extra map. Unsure if I need this
        /// </summary>
        /// <param name="name"></param>
        public Map(string name)
            {
            this.name = name;
            }


        //todo: still wip
        /// <summary>
        /// Right now no idea what I wanted with that
        /// </summary>
        public void Path()
            {
            //like a way pointer #TODO
            }


        //todo: still wip
        /// <summary>
        /// Seems like i wanted to remap this with visited rooms marked
        /// OR maybe Player Position???
        /// </summary>
        /// <param name="key"> like, "visited" ?</param>
        /// <param name="value"> the room coordinates?</param>
        public void MapAdd(string key,object value)
            {
            Dictionary<string,object> map = new Dictionary<string,object>();
            map.Add(key,value);
            WriteLine(map);
            }


        /// <summary>
        /// Simple printout of the map.
        /// </summary>
        public static void Plan()
            {
            Console.WriteLine("" +
                "||||||||||||||||||\n" +
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