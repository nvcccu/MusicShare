using BusinessLogic.Interfaces;
using CommonUtils.ServiceManager;
using Core.TransportTypes;
using MusicShareWeb.Models.User;

namespace MusicShareWeb.Models.DerzkieSchi {
    public class AdminExerciseModel : BaseModel {
        public ExerciseDto Exercise { get; set; }

        public AdminExerciseModel() : base((Account)null) { }
        public AdminExerciseModel(BaseModel baseModel) : base(baseModel) { }
        public AdminExerciseModel(int exerciseId, BaseModel baseModel) : base(baseModel) {
            Exercise = ServiceManager<IBusinessLogic>.Instance.Service.GetExercise(exerciseId);
        }

        public bool UpdateExercise(ExerciseDto exercise) {
            return ServiceManager<IBusinessLogic>.Instance.Service.UpdateExercise(exercise);
        }
        public int CreateExercise(ExerciseDto exercise) {
            return ServiceManager<IBusinessLogic>.Instance.Service.CreateExercise(exercise);
        }
    }
}