namespace _3lab3
{
    partial class Program
    {
        public class SimpleListItem<T>
        {
            public T data { get; set; }
            public SimpleListItem<T> next { get; set; }
            public SimpleListItem(T param)
            {
                this.data = param;
            }
        }
    }
}
