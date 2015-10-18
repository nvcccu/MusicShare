using System;
using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.Providers;
using CommonUtils.Config;
using CommonUtils.Log;
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
        private static readonly LoggerWrapper _logger = LoggerManager.GetLogger(typeof (BusinessLogic).FullName);

        private T LoggedAction<T>(Func<T> action) where T : new(){
            try {
                return action();
            } catch(Exception ex) {
                _logger.Error(ex);
                throw;
            }
        }
        private void LoggedAction(Action action){
            try {
                action();
            } catch(Exception ex) {
                _logger.Error(ex);
            }
        }
        

        public BusinessLogic() {
            Initial();
        }
        public void Initial() {
            ConfigHelper.LoadXml(false);
            Connector.ConnectionString = ConfigHelper.FirstTagWithTagNameInnerText("db-connection");
        }
        public long GetNextGuestId(string userAgent) {
            return LoggedAction(() => _userProvider.GetNextGuestId(userAgent));
        }
        public void AddUserAction(long guestId, ActionId actionId, long? target = null) {
            LoggedAction(() => _logProvider.AddUserAction(guestId, actionId, target));
        }
        public List<ParameterDto> GetParameters() {
            return LoggedAction(() => _designerProvider.GetParameters());
        }
        public List<ParameterValueDto> GetParameterValues() {
            return LoggedAction(() => _designerProvider.GetParameterValues());
        }
        public List<IncompatibleParameterDto> GetIncompatibleParameters() {
            return LoggedAction(() => _designerProvider.GetIncompatibleParameters());
        }
        public List<DesignerImageTransportType> GetDesignerImages() {
            return LoggedAction(() => _designerProvider.GetDesignerImages());
        }
        public List<PredefinedGuitarDto> GetPredefinedGuitars() {
            return LoggedAction(() =>  _designerProvider.GetPredefinedGuitars());
        }
        public AskThreadTransportType GetAskThread(long questionId) {
            return LoggedAction(() => _askProvider.GetAskThread(questionId));
        }
        public List<QuestionTransportType> GetAllQuestions() {
            return LoggedAction(() => _askProvider.GetAllQuestions());
        }
        public long CreateNewQuestion(QuestionDto question) {
            return LoggedAction(() => _askProvider.CreateNewQuestion(question));
        }
        public int? RegisterViaEmail(long guestId, string email, string password, string nickName) {
            return LoggedAction(() => _userProvider.RegisterViaEmail(guestId, email, password, nickName));
        }
        public bool Login(AuthTransportType auth) {
            return LoggedAction(() => _userProvider.Login(auth));
        }
        public bool IsEmailFree(string email) {
            return LoggedAction(() => _userProvider.IsEmailFree(email));
        }
        public bool IsNickNameFree(string nickName) {
            return LoggedAction(() => _userProvider.IsNickNameFree(nickName));
        }
        public AccountDto GetUser(long guestId) {
            return LoggedAction(() => _userProvider.GetUser(guestId));
        }
        public AccountDto GetUserById(long id) {
            return LoggedAction(() =>_userProvider.GetUserById(id));
        }
        public AccountDto GetUserByEmail(string email) {
            return LoggedAction(() => _userProvider.GetUserByEmail(email));
        }
        public bool IsGuestAlreadyHasAccount(long guestId) {
            return LoggedAction(() => _userProvider.IsGuestAlreadyHasAccount(guestId));
        }
        public int SaveArticle(ArticleDto article) {
            return LoggedAction(() => _articleProvider.SaveArticle(article));
        }
        public ArticleDto GetArticleById(int id) {
            return LoggedAction(() => _articleProvider.GetArticleById(id));
        }
        public List<ArticleDto> GetArticleByDateDesc(int count, int from) {
            return LoggedAction(() => _articleProvider.GetArticleByDateDesc(count, from));
        }
        public List<ProductTypeDto> GetAllProductTypes() {
            return LoggedAction(() => _marketProvider.GetAllProductTypes());
        }
        public Dictionary<PropertyDto, List<PropertyValueDto>> GetAllProductProperties(long productType) {
            return LoggedAction(() => _marketProvider.GetAllProductProperties(productType));
        }
        public Dictionary<ProductTypeDto, Dictionary<PropertyDto, List<PropertyValueDto>>> GetAllProperties() {
            return LoggedAction(() => _derzkieSchiProvider.GetAllProperties());
        }
        public int? SaveNewProduct(int productTypeId, Dictionary<int, int?> propertyValuePairs, string imageUrl, string name, int price) {
            return LoggedAction(() => _derzkieSchiProvider.SaveNewProduct(productTypeId, propertyValuePairs, imageUrl, name, price));
        }
        public List<ProductDto> GetFilteredProducts(int productTypeId, string namePart, Dictionary<int, int> propertyValuePairs) {
            return LoggedAction(() => _derzkieSchiProvider.GetFilteredProducts(productTypeId, namePart, propertyValuePairs));
        }
        public bool UpdateLesson(LessonDto lesson, int redactorAccountId, string comment) {
            return LoggedAction(() => _derzkieSchiProvider.UpdateLesson(lesson, redactorAccountId, comment));
        }
        public int CreateLesson(LessonDto lesson, int redactorAccountId, string comment) {
            return LoggedAction(() => _derzkieSchiProvider.CreateLesson(lesson, redactorAccountId, comment));
        }
        public bool UpdateExercise(ExerciseDto exercise) {
            return LoggedAction(() => _derzkieSchiProvider.UpdateExercise(exercise));
        }
        public int CreateExercise(ExerciseDto exercise) {
            return LoggedAction(() => _derzkieSchiProvider.CreateExercise(exercise));
        }
        public bool IsDerzkiy(int accountId) {
            return LoggedAction(() => _derzkieSchiProvider.IsDerzkiy(accountId));
        }
        public List<LessonHistoryDto> GetAllLessonHistory() {
            return LoggedAction(() => _derzkieSchiProvider.GetAllLessonHistory());
        }
        public Dictionary<int, int> GetUsersLessonStat(int lessonId, int accountId) {
            return LoggedAction(() => _lessonProvider.GetUsersLessonStat(lessonId, accountId));
        }
        public void SaveUsersLessonStat(int accountId, Dictionary<int, int> lessonStat) {
            LoggedAction(() => _lessonProvider.SaveUsersLessonStat(accountId, lessonStat));
        }
        public Dictionary<GuitarTechniqueDto, List<LessonDto>> GetAllLessonsGroupedByTechnique() {
            return LoggedAction(() => _lessonProvider.GetAllLessonsGroupedByTechnique());
        }
        public LessonDto GetLesson(int lessonId)  {
            return LoggedAction(() => _lessonProvider.GetLesson(lessonId));
        }
        public LessonDto GetModeratedLesson(int lessonId) {
            return LoggedAction(() => _lessonProvider.GetModeratedLesson(lessonId));
        }
        public List<ExerciseDto> GetLessonExercises(int lessonId) {
            return LoggedAction(() => _lessonProvider.GetLessonExercises(lessonId));
        }
        public GuitarTechniqueDto GetGuitarTechnique(int guitarTechniqueId) {
            return LoggedAction(() => _lessonProvider.GetGuitarTechnique(guitarTechniqueId));
        }
        public List<PlanDto> GetAllUsersPlans(int accountId) {
            return LoggedAction(() => _lessonProvider.GetAllUsersPlans(accountId));
        }
        public void CreateLessonStatNode(int accountId) {
            LoggedAction(() => _lessonProvider.CreateLessonStatNode(accountId));
        }
         public void CreatePlanNode(int accountId) {
             LoggedAction(() => _lessonProvider.CreatePlanNode(accountId));
        }
        public List<GuitarTechniqueDto> GetAllGuitarTechniques() {
            return LoggedAction(() => _lessonProvider.GetAllGuitarTechniques());
        }
        public List<LessonDto> GetAllModeratedLessons() {
            return LoggedAction(() => _lessonProvider.GetAllModeratedLessons());
        }
        public List<LessonDto> GetAllLessons() {
            return LoggedAction(() => _lessonProvider.GetAllLessons());
        }
        public ExerciseDto GetExercise(int id) {
            return LoggedAction(() => _lessonProvider.GetExercise(id));
        }
        public List<ExerciseDto> GetAllExercises() {
            return LoggedAction(() => _lessonProvider.GetAllExercises());
        }
        public List<ExerciseDto> GetExercisesByPlan(int planId) {
            return LoggedAction(() => _lessonProvider.GetExercisesByPlan(planId));
        }
        public Dictionary<int, int> GetUsersExercisesStat(int accountId) {
            return LoggedAction(() => _lessonProvider.GetUsersExercisesStat(accountId));
        }
        public Dictionary<int, List<ExerciseSpeedInDate>> GetUsersExercisesTotalStat(int accountId) {
            return LoggedAction(() => _lessonProvider.GetUsersExercisesTotalStat(accountId));
        }
        public PlanDto GetPlan(int id) {
            return LoggedAction(() => _lessonProvider.GetPlan(id));
        }
        public int SavePlan(PlanDto plan) {
            return LoggedAction(() => _lessonProvider.SavePlan(plan));
        }
        public void UpdatePlan(PlanDto plan) {
            LoggedAction(() => _lessonProvider.UpdatePlan(plan));
        }
        public void AddExerciseToPlan(int planId, int exerciseId) {
            LoggedAction(() => _lessonProvider.AddExerciseToPlan(planId, exerciseId));
        }
        public List<StatPresetDto> GetAllUsersStatPresets(int accountId) {
            return LoggedAction(() => _lessonProvider.GetAllUsersStatPresets(accountId));
        }
        public StatPresetDto SaveStatPreset(StatPresetDto statPreset) {
            return LoggedAction(() => _lessonProvider.SaveStatPreset(statPreset));
        }
        public bool UpdateStatPreset(StatPresetDto statPreset) {
            return LoggedAction(() => _lessonProvider.UpdateStatPreset(statPreset));
        }
        public bool DeleteStatPreset(int statPresetId) {
            return LoggedAction(() => _lessonProvider.DeleteStatPreset(statPresetId));
        }
        public bool SaveHomework(HomeworkDto homework) {
            return LoggedAction(() => _lessonProvider.SaveHomework(homework));
        }
    }
}