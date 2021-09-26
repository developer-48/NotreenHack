using GoodChildren.Models;
using GoodChildren.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodChildren.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserContext db;

        public HomeController(ILogger<HomeController> logger, UserContext context)
        {
            _logger = logger;
            db = context;
        }

        [Authorize]
        public IActionResult Index()
        {
            List<User> Test = db.Users.ToList();
            List<UserView> Model = new List<UserView>();
            for (int i = 0; i < Test.Count; i++)
                Model.Add(new UserView() { Id = Test[i].Id, Email = Test[i].LoginEmail });
            return View(Model);
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
        public async void LookMesseng(LookMeseng model, UserContext db)
        {
            ChatState test = db.ChatStates.FirstOrDefault(u => u.UserId == model.UserId && u.ChatId == model.ChatId);
            test.State = model.State;
            await db.SaveChangesAsync();
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
