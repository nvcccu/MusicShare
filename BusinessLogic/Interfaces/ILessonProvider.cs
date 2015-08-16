using System.Collections.Generic;
using Core.TransportTypes;

namespace BusinessLogic.Interfaces {
    public interface ILessonProvider {
        void CreateLessonStatNode(int accountId);
        void CreatePlanNode(int accountId);
        Dictionary<int, int> GetUsersLessonStat(int lessonId, int accountId);
        void SaveUsersLessonStat(int accountId, Dictionary<int, int> lessonStat);
        Dictionary<GuitarTechniqueDto, List<LessonDto>> GetAllLessonsGroupedByTechnique();
        LessonDto GetLesson(int lessonId);
        List<ExerciseDto> GetLessonExercises(int lessonId);
        GuitarTechniqueDto GetGuitarTechnique(int guitarTechniqueId);
        List<GuitarTechniqueDto> GetAllGuitarTechniques();
        List<PlanDto> GetAllUsersPlans(int accountId);
        List<LessonDto> GetAllLessons();
        List<ExerciseDto> GetAllExercises();
        List<ExerciseDto> GetExercisesByPlan(int planId);
        Dictionary<int, int> GetUsersExercisesStat(int accountId);
        Dictionary<int, List<ExerciseSpeedInDate>> GetUsersExercisesTotalStat(int accountId);
        PlanDto GetPlan(int id);  
        int SavePlan(PlanDto plan);
        void UpdatePlan(PlanDto plan);
    }
}