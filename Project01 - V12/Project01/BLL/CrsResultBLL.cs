using Project01.Models;

namespace Project01.BLL
{
    public class CrsResultBLL
    {
        private readonly TrCenterContext trCenterContext;

        public CrsResultBLL(TrCenterContext trCenterContext)
        {
            this.trCenterContext = trCenterContext;
        }



        //TrCenterContext trCenterContext = new TrCenterContext();


        public decimal GetResult(int traineeId)
        {
            var result = trCenterContext.CrsResult.FirstOrDefault(c => c.TraineeId == traineeId);
            if (result == null)
            {
                return 0;
            }
            return result.Degree.Value;
        }

    }
}
