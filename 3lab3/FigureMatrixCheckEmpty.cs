namespace _3lab3
{
    partial class Program
    {
        class FigureMatrixCheckEmpty : IMatrixCheckEmpty<Figure>
        {
            public Figure getEmptyElement()
            {
                return null;
            }
            public bool checkEmptyElement(Figure element)
            {
                bool Result = false;
                if (element == null)
                {
                    Result = true;
                }
                return Result;
            }
        }
    }
}
