## Api
### Документаци к Api в виде postmancollection
1. Скачать библиотеку [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.WebApi)

2. К контроллерам добавить описание
   ```
  [SwaggerResponse(HttpStatusCode.OK, Description = "Возращает все конкретный пропуск/отгул")]
  [SwaggerResponse(HttpStatusCode.NotFound, Description ="Возращает когда не найден прогул")]

  public IHttpActionResult GetAbsence(int id)
  {
     Absence absence = db.Absence.Find(id);
     if (absence == null)
     {
         return NotFound();
     }

     return Ok(absence);
  }
   ```
3. Перети по ссылке ``` "https://localhost:63452//swagger/docs/v1" ```
4. Скопировать контент страницы в json файл 
