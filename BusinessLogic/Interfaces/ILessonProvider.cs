using Core.TransportTypes;

namespace BusinessLogic.Interfaces {
    public interface ILessonProvider {
        public LessonStatDto GetUsersLessonStat(int accountId)
    }
}