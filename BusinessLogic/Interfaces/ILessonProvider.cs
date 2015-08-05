using System.Collections.Generic;
using Core.TransportTypes;

namespace BusinessLogic.Interfaces {
    public interface ILessonProvider {
        LessonStatDto GetUsersLessonStat(int accountId);
        void SaveUsersLessonStat(LessonStatDto lessonStatDto);
        Dictionary<GuitarTechniqueDto, List<LessonDto>> GetAllLessonsGroupedByTechnique();
        LessonDto GetLesson(int lessonId);
    }
}