
namespace Recursion;

public class _6_Subsequences
{

    public static List<List<int>> ans = [];

    public static void Subsets(int index, int[] list, List<int> subset) {
        if(index >= list.Length) {
            ans.Add(new List<int>(subset));
            return;
        }

        subset.Add(list[index]);

        Subsets(index + 1, list, subset);

        subset.Remove(list[index]);

        Subsets(index + 1, list, subset);
    }

    public static List<List<int>> GenerateSubsets(int[] list) {
        
        Subsets(0, list, []);

        return ans;
    }

    public static void Run() {
         var arr = new List<int> {1, 2, 3};

         var a = new int[] {1, 2, 3};

         List<List<int>> subsets = GenerateSubsets(a);

         foreach(var list in subsets) {
            Console.WriteLine(string.Join(",", list));
         }
    }
}
