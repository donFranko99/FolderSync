public static class SyncOperator
{
    public static void SyncFolders(string sourcePath, string replicaPath)
    {
        var subDirectories = Directory.GetDirectories(sourcePath);
        var sourceFiles = Directory.EnumerateFiles(sourcePath);

        //TODO: clear replica first

        foreach (var file in sourceFiles)
        {
            File.Copy(file, replicaPath);
        }

        if (subDirectories.Count() != 0)
        {
            foreach (var dir in subDirectories)
            {
                string replicaSubdirectoryName = replicaPath + dir.Split("\\").Last();
                Directory.CreateDirectory(replicaSubdirectoryName);
                SyncFolders(dir, replicaSubdirectoryName);
            }
        }
    }
    
    static void CleanReplica(string replicaPath)
    {
        var replicaSubDirectories = Directory.GetDirectories(replicaPath);
        var replicaFiles = Directory.EnumerateFiles(replicaPath);

        foreach (var file in replicaFiles)
        {
            File.Delete(file);
        }
        foreach (var dir in replicaSubDirectories)
        {
            CleanReplica(dir);
            Directory.Delete(dir);
        }
        
    }
}