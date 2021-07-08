using System;
using System.Collections.Generic;
using Telegram;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace Telegram_Bot
{

    class Program
    {

        private static string token { get; set; } = "1738271195:AAGevahUyevb_XvGiWu_i_vL9byyNwkLNtI";
        private static TelegramBotClient client;


        static void Main(string[] args)
        {

            client = new TelegramBotClient(token); // Инициализируем бота, используя наш ключ
            client.StartReceiving(); // Добавляем начало приема сообщений

            client.OnMessage += OnMessageHandler; // В этом методе мы будем прописывать все действия, которые будет выполнять бот, когда ему будут приходить сообщения

            Console.ReadLine(); // Запрашиваем ввод в консоль, чтобы программа сразу не закрывалась
            client.StopReceiving();

        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;

            if (msg.Text != null) // Проверка работоспособности
            {
                Console.WriteLine($"Пришло сообщение: {msg.Text}");

                switch (msg.Text)
                {
                    case "Sticker":
                        var stic = await client.SendStickerAsync(
                            chatId: msg.Chat.Id,
                            sticker: "https://tgram.ru/wiki/stickers/img/Batska/png/1.png",
                            replyToMessageId: msg.MessageId,
                            replyMarkup: GetButtons()) ;

                        break;

                    default:
                        await client.SendTextMessageAsync(msg.Chat.Id, "Select command:");

                        break;
                }
                /*             
                       
                          Бот будет отправлять стикеры в ответ на сообщения:

                var stic = await client.SendStickerAsync(
                    chatId: msg.Chat.Id,
                    sticker: "https://tgram.ru/wiki/stickers/img/Batska/png/1.png",
                    replyToMessageId: msg.MessageId);

                */


            }
        }

        // Этот метод будет возвращать клавиатуру, которая состоит из списка списков кнопок
        private static IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>> // Список списков кнопок
                {
                    new List<KeyboardButton> { new KeyboardButton { Text = "Sticker" }, new KeyboardButton { Text = " C#" } },
                    new List<KeyboardButton>
                    { new KeyboardButton { Text = "123" }, new KeyboardButton { Text = "456" }

                    }
                }
            };
        }
    }
}
