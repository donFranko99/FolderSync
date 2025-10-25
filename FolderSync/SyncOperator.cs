public static class SyncOperator
{
    public static void SyncFolders(string sourcePath, string replicaPath)
    {
        //TODO: clear replica first

        var subDirectories = Directory.GetDirectories(sourcePath);
        var sourceFiles = Directory.EnumerateFiles(sourcePath);

        foreach (var file in sourceFiles)
        {
            File.Copy(file, replicaPath);
        }
        
        if(subDirectories.Count != 0)
        {
            foreach(var dir in subDirectories)
            {
                string replicaSubdirectoryName = replicaPath + dir.Split("\\").Last;
                Directory.CreateDirectory(replicaSubdirectoryName);
                SyncFolders(dir, replicaSubdirectoryName);
            }
        }
    }
}