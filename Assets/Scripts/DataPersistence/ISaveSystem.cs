using System.Threading.Tasks;

namespace ClickerPrototype.DataPersistence
{
    public interface ISaveSystem
    {
        void Save(GameData gameData);
        Task<GameData> Load();
    }
}