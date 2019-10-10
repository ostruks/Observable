namespace Library
{
    public class ClassCounter
    {
        public delegate void MethodContainer();
        public event MethodContainer Handler;
        public void Count ()
        {
            int i = 0;
            while (i < 100)
            {
                i++;
                if (i == 71)
                {
                    if (Handler != null)
                        Handler();
                    break;
                }
            }
        }
    }
}
