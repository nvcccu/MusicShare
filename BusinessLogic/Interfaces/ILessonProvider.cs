using Core.TransportTypes;

namespace BusinessLogic.Interfaces {
    public interface ILessonProvider {
        LessonStatDto GetUsersLessonStat(int accountId);
        void SaveUsersLessonStat(LessonStatDto lessonStatDto);
    }
}