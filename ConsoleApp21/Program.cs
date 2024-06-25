internal class Program
{
    static void Main(string[] args)
    {
     Algorithm.Start();
    }
}
public class Algorithm
{
    static int N = 6;
    static  int[,] graph = new int[,]
            {
        { int.MaxValue, 10, 12, 5, 7, 2 },
        { 10, int.MaxValue, 3, 2, 5, 12 },
        { 12, 3, int.MaxValue, 4, 8, 10 },
        { 5, 2, 4, int.MaxValue, 10, 5 },
        { 7, 5, 8, 10, int.MaxValue, int.MaxValue },
        { 2, 12, 10, 5, int.MaxValue, int.MaxValue }
            };

  public  static void Start(int startVertex = 0)
    {
        List<int> path = FindShortestPath(startVertex);

        Console.WriteLine("Оптимальный путь:");
        foreach (int vertex in path)
        {
            Console.Write(vertex + " ");
        }


        List<int> FindShortestPath(int startVertex)
        {
            bool[] visited = new bool[N];
            List<int> path = new List<int>();

            int currentVertex = startVertex;
            path.Add(currentVertex);
            visited[currentVertex] = true;

            for (int i = 0; i < N - 1; i++)
            {
                int nextVertex = -1;
                int minDistance = int.MaxValue;

                for (int j = 0; j < N; j++)
                {
                    if (!visited[j] && graph[currentVertex, j] < minDistance)
                    {
                        nextVertex = j;
                        minDistance = graph[currentVertex, j];
                    }
                }

                if (nextVertex != -1)
                {
                    visited[nextVertex] = true;
                    path.Add(nextVertex);
                    currentVertex = nextVertex;
                }
            }
            path.Add(startVertex);

            return path;
        }
    }
}
