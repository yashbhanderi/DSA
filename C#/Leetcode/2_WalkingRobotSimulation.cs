public class WalkingRobotSimulation {

    public static int RobotSim(int[] commands, int[][] obstacles) {
        if(commands.Length == 0) return 0;

        var map = new Dictionary<int, List<int>>();

        foreach(var obs in obstacles) {
            if(!map.ContainsKey(obs[0])) map.Add(obs[0], []);

            if(map.TryGetValue(obs[0], out var list)) {
                list.Add(obs[1]);
            }
        }

        int X = 0, Y = 0;
        var direction = 0;
        int ans = 0;

        foreach(var command in commands) {

            if(command == -1) {
                direction = (direction + 1) % 4;
            }
            else if(command == -2) {
                direction = (direction + 3) % 4;
            }
            else {
                int K = command;
                while(K-- > 0) {
                    if(direction == 0) {

                        if(map.TryGetValue(X, out var list)) {
                            if(list.Contains(Y+1)) break;
                        }

                        Y ++;
                    }
                    else if(direction == 1) {

                        if(map.TryGetValue(X+1, out var list)) {
                            if(list.Contains(Y)) break;
                        }

                        X ++;
                    }
                    else if(direction == 2) {

                        if(map.TryGetValue(X, out var list)) {
                            if(list.Contains(Y-1)) break;
                        }

                        Y --;
                    }
                    else {

                        if(map.TryGetValue(X-1, out var list)) {
                            if(list.Contains(Y)) break;
                        }

                        X --;
                    }   
                }
            }

            ans = int.Max(ans, X*X + Y*Y);
        }

        return ans;
    }

    public static void Run() {
        var commands = new int[] {6,-1,-1,6};
        var obstacles = new int[][] {};

        var ans = RobotSim(commands, obstacles);

        System.Console.WriteLine(ans);
    }
}