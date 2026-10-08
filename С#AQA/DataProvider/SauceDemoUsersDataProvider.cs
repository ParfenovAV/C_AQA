namespace C_AQA.DataProvider
{
      public static class SauceDemoUsersDataProvider
    {
        private const string UsersDataFilePath = @"Resources\SauceDemoUsers.csv";

        public static IEnumerable<TestCaseData> GetValidUsers()
        {
            // папка, из которой запускаются тесты (bin/Debug/net10.0)
            string baseDirectory = AppContext.BaseDirectory;
            // полный путь к CSV-файлу
            string fullPath = Path.Combine(baseDirectory, UsersDataFilePath);
            // читаем все строки файла
            var lines = File.ReadAllLines(fullPath);

            // начинаем с 1, потому что строка 0 — заголовок "username,password"
            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];

                // пропускаем пустые строки (например, пустую строку в конце файла)
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                string[] parts = line.Split(',');
                string userName = parts[0].Trim();
                string password = parts[1].Trim();

                // каждый yield return = один отдельный запуск теста
                // SetName — понятное имя в Test Explorer, например "Login_problem_user"
                yield return new TestCaseData(userName, password)
                    .SetName($"Login_{userName}");
            }
        }
    }
}