using System.Collections.Generic;
using Core.TransportTypes;

namespace BusinessLogic.Interfaces {
    public interface ILessonProvider {
        void CreateLessonStatNode(int accountId);
        Dictionary<int, int> GetUsersLessonStat(int lessonId, int accountId);
        void SaveUsersLessonStat(int accountId, int lessonId, Dictionary<int, int> lessonStat);
        Dictionary<GuitarTechniqueDto, List<LessonDto>> GetAllLessonsGroupedByTechnique();
        LessonDto GetLesson(int lessonId);
        List<ExerciseDto> GetLessonExercises(int lessonId);
        GuitarTechniqueDto GetGuitarTechnique(int guitarTechniqueId);
    }
}