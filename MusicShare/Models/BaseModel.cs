using MusicShareWeb.Models.User;

namespace MusicShareWeb.Models {
    public class BaseModel {
        public Account CurrentUser { get; set; }

        public BaseModel(Account currentUser) {
            CurrentUser = currentUser;
        }
        protected BaseModel(BaseModel baseModel) {
            CurrentUser = baseModel.CurrentUser;
        }
    }
}