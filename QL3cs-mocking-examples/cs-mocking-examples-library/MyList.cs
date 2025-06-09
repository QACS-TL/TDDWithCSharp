namespace cs_mocking_examples_library
{
    public class MyList<T> : List<T>
    {
        public virtual long GetSize()
        {
            return this.Count;
        }
    }
}
