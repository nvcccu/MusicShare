namespace Core.Enums {
    public enum ActionId {
        /// <summary>
        /// открыл страницу поиска
        /// </summary>
        OpenSearch = 1,
        /// <summary>
        /// Сохранил скорость метронома на странице урока
        /// </summary>
        SaveSpeedFromLesson = 2,
        /// <summary>
        /// Сохранил скорость метронома на странице занятия по плану
        /// </summary>
        SaveSpeedFromTrain = 3,
        /// <summary>
        /// Открыл свою статистику
        /// </summary>
        OpenStat = 4,
        /// <summary>
        /// Выбор пресета статистики
        /// </summary>
        SelectStatPreset = 5,
        /// <summary>
        /// Создание нового пресета статистики
        /// </summary>
        CreateStatPreset = 6,
        /// <summary>
        /// Удаление пресета статистики
        /// </summary>
        DeleteStatPreset = 7,
        /// <summary>
        /// Обновление пресета статистики
        /// </summary>
        SaveStatPreset = 8,
        /// <summary>
        /// Переименование пресета статистики
        /// </summary>
        RenameStatPreset = 9,
        /// <summary>
        /// Смена периода просмотра статистики
        /// </summary>
        ChangeStatPeriod = 9,
        
    }
}