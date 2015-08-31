using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.Providers;
using CommonUtils.Config;
using Core.Enums;
using Core.TransportTypes;
using DAO;

namespace BusinessLogic {
    public class BusinessLogic : IBusinessLogic {
        private readonly UserProvider _userProvider = new UserProvider();
        private readonly LogProvider _logProvider = new LogProvider();
        private readonly DerzkieSchiProvider _derzkieSchiProvider = new DerzkieSchiProvider();
        private readonly DesignerProvider _designerProvider = new DesignerProvider();
        private readonly AskProvider _askProvider = new AskProvider();
        private readonly ArticleProvider _articleProvider = new ArticleProvider();
        private readonly MarketProvider _marketProvider = new MarketProvider();
        private readonly LessonProvider _lessonProvider = new LessonProvider();
        public BusinessLogic() {
            Initial();
        }
        public void Initial() {
            ConfigHelper.LoadXml(false);
            Connector.ConnectionString = ConfigHelper.FirstTagWithTagNameInnerText("db-connection");
        }
        public long GetNextGuestId(string userAgent) {
            return _userProvider.GetNextGuestId(userAgent);
        }
        public void AddUserAction(long guestId, ActionId actionId, long? target = null) {
            _logProvider.AddUserAction(guestId, actionId, target);
        }
        public List<ParameterDto> GetParameters() {
            return _designerProvider.GetParameters();
        }
        public List<ParameterValueDto> GetParameterValues() {
            return _designerProvider.GetParameterValues();
        }
        public List<IncompatibleParameterDto> GetIncompatibleParameters() {
            return _designerProvider.GetIncompatibleParameters();
        }
        public List<DesignerImageTransportType> GetDesignerImages() {
            return _designerProvider.GetDesignerImages();
        }
        public List<PredefinedGuitarDto> GetPredefinedGuitars() {
            return _designerProvider.GetPredefinedGuitars();
        }
        public AskThreadTransportType GetAskThread(long questionId) {
            return _askProvider.GetAskThread(questionId);
        }
        public List<QuestionTransportType> GetAllQuestions() {
            return _askProvider.GetAllQuestions();
        }
        public long CreateNewQuestion(QuestionDto question) {
            return _askProvider.CreateNewQuestion(question);
        }
        public int? RegisterViaEmail(long guestId, string email, string password, string nickName) {
            return _userProvider.RegisterViaEmail(guestId, email, password, nickName);
        }
        public bool Login(AuthTransportType auth) {
            return _userProvider.Login(auth);
        }
        public bool IsEmailFree(string email) {
            return _userProvider.IsEmailFree(email);
        }
        public bool IsNickNameFree(string nickName) {
            return _userProvider.IsNickNameFree(nickName);
        }
        public AccountDto GetUser(long guestId) {
            return _userProvider.GetUser(guestId);
        }
        public AccountDto GetUserById(long id) {
            return _userProvider.GetUserById(id);
        }
        public AccountDto GetUserByEmail(string email) {
            return _userProvider.GetUserByEmail(email);
        }
        public bool IsGuestAlreadyHasAccount(long guestId) {
            return _userProvider.IsGuestAlreadyHasAccount(guestId);
        }
        public int SaveArticle(ArticleDto article) {
            return _articleProvider.SaveArticle(article);
        }
        public ArticleDto GetArticleById(int id) {
            return _articleProvider.GetArticleById(id);
        }
        public List<ArticleDto> GetArticleByDateDesc(int count, int from) {
            return _articleProvider.GetArticleByDateDesc(count, from);
        }
        public List<ProductTypeDto> GetAllProductTypes() {
            return _marketProvider.GetAllProductTypes();
        }
        public Dictionary<PropertyDto, List<PropertyValueDto>> GetAllProductProperties(long productType) {
            return _marketProvider.GetAllProductProperties(productType);
        }
        public Dictionary<ProductTypeDto, Dictionary<PropertyDto, List<PropertyValueDto>>> GetAllProperties(){
            return _derzkieSchiProvider.GetAllProperties();
        }
        public int? SaveNewProduct(int productTypeId, Dictionary<int, int?> propertyValuePairs, string imageUrl, string name, int price){
            return _derzkieSchiProvider.SaveNewProduct(productTypeId, propertyValuePairs, imageUrl, name, price);
        }
        public List<ProductDto> GetFilteredProducts(int productTypeId, string namePart, Dictionary<int, int> propertyValuePairs) {
            return _derzkieSchiProvider.GetFilteredProducts(productTypeId, namePart, propertyValuePairs);
        }
        public Dictionary<int, int> GetUsersLessonStat(int lessonId, int accountId) {
            return _lessonProvider.GetUsersLessonStat(lessonId, accountId);
        }
        public void SaveUsersLessonStat(int accountId, Dictionary<int, int> lessonStat) {
            _lessonProvider.SaveUsersLessonStat(accountId, lessonStat);
        }
        public Dictionary<GuitarTechniqueDto, List<LessonDto>> GetAllLessonsGroupedByTechnique() {
            return _lessonProvider.GetAllLessonsGroupedByTechnique();
        }
        public LessonDto GetLesson(int lessonId) {
            return _lessonProvider.GetLesson(lessonId);
        }
        public List<ExerciseDto> GetLessonExercises(int lessonId) {
            return _lessonProvider.GetLessonExercises(lessonId);
        }
        public GuitarTechniqueDto GetGuitarTechnique(int guitarTechniqueId) {
            return _lessonProvider.GetGuitarTechnique(guitarTechniqueId);
        }
        public List<PlanDto> GetAllUsersPlans(int accountId) {
            return _lessonProvider.GetAllUsersPlans(accountId);
        }
        public void CreateLessonStatNode(int accountId) {
            _lessonProvider.CreateLessonStatNode(accountId);
        }
         public void CreatePlanNode(int accountId) {
            _lessonProvider.CreatePlanNode(accountId);
        }
        public List<GuitarTechniqueDto> GetAllGuitarTechniques() {
            return _lessonProvider.GetAllGuitarTechniques();
        }
        public List<LessonDto> GetAllLessons() {
            return _lessonProvider.GetAllLessons();
        }
        public List<ExerciseDto> GetAllExercises() {
            return _lessonProvider.GetAllExercises();
        }
        public List<ExerciseDto> GetExercisesByPlan(int planId) {
            return _lessonProvider.GetExercisesByPlan(planId);
        }
        public Dictionary<int, int> GetUsersExercisesStat(int accountId) {
            return _lessonProvider.GetUsersExercisesStat(accountId);
        }
        public Dictionary<int, List<ExerciseSpeedInDate>> GetUsersExercisesTotalStat(int accountId) {
            return _lessonProvider.GetUsersExercisesTotalStat(accountId);
        }
        public PlanDto GetPlan(int id) {
            return _lessonProvider.GetPlan(id);
        }
        public int SavePlan(PlanDto plan) {
            return _lessonProvider.SavePlan(plan);
        }
        public void UpdatePlan(PlanDto plan) {
            _lessonProvider.UpdatePlan(plan);
        }
        public void AddExerciseToPlan(int planId, int exerciseId) {
            _lessonProvider.AddExerciseToPlan(planId, exerciseId);
        }
        public List<StatPresetDto> GetAllUsersStatPresets(int accountId) {
            return _lessonProvider.GetAllUsersStatPresets(accountId);
        }
        public StatPresetDto SaveStatPresets(StatPresetDto statPreset) {
            return _lessonProvider.SaveStatPresets(statPreset);
        }
        public bool UpdateStatPresets(StatPresetDto statPreset) {
            return _lessonProvider.UpdateStatPresets(statPreset);
        }
        public bool DeleteStatPreset(int statPresetId) {
            return _lessonProvider.DeleteStatPreset(statPresetId);
        }
    }
}