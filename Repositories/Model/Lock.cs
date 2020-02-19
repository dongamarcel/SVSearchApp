using Repositories.Model;

namespace Model
{
    public class Lock : AbstractSearchModel
    {
        public override string foreignID { get => buildingId; }
    }
}
