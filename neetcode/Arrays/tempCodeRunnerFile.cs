foreach (var e in nums)
            {
                map.TryAdd(e, 1);
            }

            foreach (var e in nums)
            {
                if (!map.ContainsKey(e - 1))
                {
                    int cnt = 1, next = e + 1;
                    while (map.TryGetValue(next, out var nextValue) && nextValue != 0)
                    {
                        cnt += map[next];
                        map[next] = 0;
                        next++;
                    }
                    longestSequence = Math.Max(longestSequence, cnt);
                }
            }