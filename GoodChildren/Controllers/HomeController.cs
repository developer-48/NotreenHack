using GoodChildren.Models;
using GoodChildren.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

using System.Threading.Tasks;

namespace GoodChildren.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserContext db;
        private readonly IHostingEnvironment hostingEnvironment;
        public HomeController(ILogger<HomeController> logger, UserContext context, IHostingEnvironment environment )
        {
            hostingEnvironment = environment;
            _logger = logger;
            db = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            User Im = db.Users.FirstOrDefault(u => u.LoginEmail == User.Identity.Name);
            int Coins = Im.Coins;
            ViewBag.Coins = Coins;
            List<User> Test = db.Users.ToList();
            List<UserView> Model = new List<UserView>();
            for (int i = 0; i < Test.Count; i++)
                Model.Add(new UserView() { Id = Test[i].Id, Email = Test[i].LoginEmail });
            return View(Model);
        }
        public IActionResult Events()
        {
            List<Sobytiya> model = db.Events.ToList();
            User Im = db.Users.FirstOrDefault(u => u.LoginEmail == User.Identity.Name);
            ViewBag.Coins = Im.Coins;
            return View(model);
        }
        public IActionResult Proffer()
        {
            User Im = db.Users.FirstOrDefault(u => u.LoginEmail == User.Identity.Name);
            int Coins = Im.Coins;
            return View(Coins);
        }
        public IActionResult Mentoring()
        {
            User Im = db.Users.FirstOrDefault(u => u.LoginEmail == User.Identity.Name);
            int Coins = Im.Coins;
            return View(Coins);
        }
        [HttpPost]
        public async void AddEvents(SobytiyaFile model)
        {
            long size = model.files.Sum(f => f.Length);

            // full path to file in temp location
            var filePath = Path.GetTempFileName();

            foreach (var formFile in model.files)
            {
                var uploads = Path.Combine(hostingEnvironment.WebRootPath, "images");
                var fullPath = Path.Combine(uploads, GetUniqueFileName(formFile.FileName));
                formFile.CopyTo(new FileStream(fullPath, FileMode.Create));

            }


            //db.Events.Add(model);
            await db.SaveChangesAsync();
        }
        private string GetUniqueFileName(string fileName)
        {
            fileName = Path.GetFileName(fileName);
            return Path.GetFileNameWithoutExtension(fileName)
                      + "_"
                      + Guid.NewGuid().ToString().Substring(0, 4)
                      + Path.GetExtension(fileName);
        }
        public IActionResult message(int? id)
        {
            List<User> Test = db.Users.ToList();
            User Name = Test.FirstOrDefault(u => u.Id == id);
            User MyName = Test.FirstOrDefault(u => u.LoginEmail == User.Identity.Name);
            Name.Password = " ";
            ViewBag.HerName = Name.fullName;
            ViewBag.MyName = MyName.fullName;
            Chat TestChat = db.Chats.FirstOrDefault(u => (u.ReciverId == MyName.Id && u.SenderId == Name.Id) || (u.ReciverId == Name.Id && u.SenderId == MyName.Id));
            if (TestChat == null) TestChat = new Chat() { Id = 0 };
            ChatView model = new ChatView() { chatId = TestChat.Id, ReciverId = Name.Id, SenderId = MyName.Id, ReciverName = Name.LoginEmail, SenderName = MyName.LoginEmail };
            if (model.chatId != 0)
            {
                List<Chat> result = new List<Chat>();
                result = db.Chats.Where(u => (u.ReciverId == model.ReciverId && u.SenderId == model.SenderId) || (u.ReciverId == model.SenderId && u.SenderId == model.ReciverId)).ToList();
                ViewBag.Messanges = result;
            }
            return View(model);
        }
        [HttpPost]
        public async Task message(Chat chat)
        {
            if (chat.ChatId == 0)
            {
                try
                {
                    chat.ChatId = db.Chats.Max(t => t.ChatId) + 1;
                }
                catch
                {
                    chat.ChatId = 1;
                    await db.ChatStates.AddAsync(new ChatState() { ChatId = chat.ChatId, UserId = chat.SenderId, State = true });
                    await db.ChatStates.AddAsync(new ChatState() { ChatId = chat.ChatId, UserId = chat.ReciverId, State = true });
                }
            }
            await db.Chats.AddAsync(chat);
            await db.SaveChangesAsync();
        }
        [HttpGet]
        public List<Chat> DownloadMessage(ChatView model)
        {
            if (model.chatId != 0)
            {
                List<Chat> result = new List<Chat>();
                result = db.Chats.Where(u => (u.ReciverId == model.ReciverId&&u.SenderId==model.SenderId)|| (u.ReciverId == model.SenderId && u.SenderId ==model.ReciverId )).ToList();
                return result;
            }
            else return null;
        }
        [HttpPost]
        public void LookMesseng(LookMeseng model)
        {
            ChatState test = db.ChatStates.FirstOrDefault(u => u.UserId == model.UserId && u.ChatId == model.ChatId);
            test.State = model.State;
            db.ChatStates.Update(test);
            db.SaveChanges();
        }
        [HttpPost]
        public async void Coins(CoinsesModel model)
        {
            User test1 = db.Users.FirstOrDefault(u => u.Id == model.SenderId);
            User test = db.Users.FirstOrDefault(u => u.Id == model.RevicerId);
            test.Coins += model.Coinses;
            test1.Coins -= model.Coinses;
            db.Users.Update(test1);
            db.Users.Update(test);
            db.SaveChanges();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
