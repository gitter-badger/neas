using System;
using System.IO;

namespace Nea.Core
{
    internal class ConfigManager : IConfigManager
    {
        private readonly string _dir;
        
        public ConfigManager(string dir)
        {
            _dir = dir;
            if (!Directory.Exists(_dir))
                Directory.CreateDirectory(_dir);
        }
        
        public void Read(IModule module)
        {
            var path = BuildPath(module.Name);
            if (!File.Exists(path))
                return;
                
            var config = File.ReadAllLines(path);
            module.Config.Read(config);
        }
        
        public void Write(IModule module)
        {
            var path = BuildPath(module.Name);
            var config = module.Config.Write();
            File.WriteAllLines(path, config);
        }
        
        private string BuildPath(string name)
        {
            return Path.Combine(_dir, name, ".mcf");   
        }
    }  
}