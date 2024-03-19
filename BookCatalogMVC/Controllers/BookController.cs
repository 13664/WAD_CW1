using Microsoft.AspNetCore.Mvc;
using System.Text;
using BookCatalogMVC.Models;
using Newtonsoft.Json;

namespace BookCatalogMVC.Controllers
{
    public class BookController : Controller
    {

        Uri baseAddress = new Uri("https://localhost:7174/api/book");
        private readonly HttpClient _httpClient;

        public BookController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = baseAddress;
        }

        [HttpGet]
        public IActionResult Index()
        {

            List<Book> books = new List<Book>();
            HttpResponseMessage response = _httpClient.GetAsync(baseAddress + "/GetAll").Result;

            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;
                books = JsonConvert.DeserializeObject<List<Book>>(data);
            }
            return View(books);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book books)
        {


            try
            {
                string data = JsonConvert.SerializeObject(books);
                StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage responseMessage = _httpClient.PostAsync(_httpClient.BaseAddress + "/Create",
                    stringContent).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                return View(books);
            }
            catch (Exception ex)
            {

                TempData["ErrorCreate"] = ex.Message;
                return View(books);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {


            try
            {
                Book toDoItems = new Book();
                HttpResponseMessage responseMessage = _httpClient.GetAsync(_httpClient.BaseAddress + "/GetByID/" + id).Result;
                if (responseMessage.IsSuccessStatusCode)
                {
                    string data = responseMessage.Content.ReadAsStringAsync().Result;
                    toDoItems = JsonConvert.DeserializeObject<Book>(data);

                }
                return View(toDoItems);

            }
            catch (Exception ex)
            {

                TempData["ErrorEdit"] = ex.Message;
                return View();
            }


        }

        [HttpPost]
        public IActionResult Edit(Book book)
        {
            string data = JsonConvert.SerializeObject(book);
            StringContent stringContent = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage responseMessage = _httpClient.PutAsync(_httpClient.BaseAddress + "/Modify/" + book.BookId, stringContent).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(book);
        }
    }
}
