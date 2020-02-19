using Repositories.Model;

namespace Model
{
    public class Medium : AbstractSearchModel
    {
        public override string foreignID { get => groupId; }
    }
}
