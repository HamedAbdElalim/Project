using Project01.Models;

namespace Project01.BLL
{
    public class TraineeBLL
    {
        private readonly TrCenterContext trCenterContext;

        public TraineeBLL(TrCenterContext trCenterContext)
        {
            this.trCenterContext = trCenterContext;
        }

        //TrCenterContext trCenterContext = new TrCenterContext();


        //trCenterContext.trainee.
        public List<Trainee> GetTrainees()
        {
            return trCenterContext.Trainee.ToList();
        }


        public Trainee GetTrainee(int id)
        {
            return trCenterContext.Trainee.Find(id);
        }

    }
}
