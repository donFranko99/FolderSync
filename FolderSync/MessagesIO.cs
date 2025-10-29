public static class MessagesIO
{
    public static string AskForAndVerifySourcePath()
    {
        string sourcePath = "";
        System.Console.WriteLine("Enter source path: ");
        sourcePath += Console.ReadLine();
        if (Directory.Exists(sourcePath))
            return sourcePath;
        return "";
    }

    public static string AskForAndVerifyReplicaPath()
    {
        string replicaPath = "";
        System.Console.WriteLine("Enter replica path: ");
        replicaPath += Console.ReadLine();
        if (Directory.Exists(replicaPath))
            return replicaPath;
        return "";
    }

    public static int AskForAndVerifySyncInterval()
    {
        System.Console.WriteLine("Enter desired synchronization interval (in seconds): ");
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int syncInterval))
            return syncInterval;
        return 10;
    }

    public static bool AskForReplicaClean(bool isClean)
    {
        if (!isClean)
        {
            System.Console.WriteLine("Your replica directory is not empty.\nTo proceed with the sync it needs to be clean.\nDo you want to clean it now? (type y to clean)");
            string? shouldClean = Console.ReadLine();
            switch (shouldClean)
            {
                case "y":
                    PrintCleaningMessage();
                    return true;
                default:
                    return false;
            }
        }
        return false;
    }

    public static void PrintStartingProcessMessage()
    {
        System.Console.WriteLine("Starting synchronization process...");
    }

    public static void SynchronisationCompleteMessage()
    {
        System.Console.WriteLine("Synchronization complete");
    }

    public static void PrintAbortMessage()
    {
        System.Console.WriteLine("Operation aborted");
    }

    public static void PrintCleaningMessage()
    {
        System.Console.WriteLine("Cleaning replica directory");
    }
    
    public static void PrintEscapeMessage()
    {
        System.Console.WriteLine("To disable the synchronization process press ESC button");
    }
}