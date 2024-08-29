import java.util.stream.IntStream;

public class Program {
    public static void main(String[] args) {
        var arr = new int[] {0,1,2,2,3,0,4,2};

        int val = 2;

        var ans = new int[arr.length];

        int cnt = 0;
        for (int arr2 : arr) {
            if(arr2 != val) ans[cnt++] = arr2;
        }

        arr = ans;
    }
}
