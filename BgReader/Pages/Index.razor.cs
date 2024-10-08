namespace BgReader.Pages;

using Microsoft.AspNetCore.Components;

public partial class Index : ComponentBase
{
    private bool IncludeCapitalLetters { get; set; } = true;
    private bool IncludeSmallLetters { get; set; } = true;
    private bool IncludeLetterPairs { get; set; } = true;
    private bool IncludeWords { get; set; } = true;
    private bool IncludeSentences { get; set; } = true;
    private bool CapitalizeWords { get; set; } = false;

    private string? CurrentText { get; set; } = null!;

    public void SetText()
    {

        IEnumerable<string> texts = [];
        int itemsCount = 0;

        if (IncludeCapitalLetters)
        {
            texts = texts.Concat(CapitalLetters);
            itemsCount += CapitalLetters.Length;
        }

        if (IncludeSmallLetters)
        {
            texts = texts.Concat(SmallLetters);
            itemsCount += SmallLetters.Length;
        }

        if (IncludeLetterPairs)
        {
            texts = texts.Concat(LetterPairs);
            itemsCount += LetterPairs.Length;
        }

        if (IncludeWords)
        {
            IEnumerable<string> wordsToInclude = Words;

            if(CapitalizeWords)
            {
                wordsToInclude = wordsToInclude.Select(w => w.ToUpper());
            }

            texts = texts.Concat(wordsToInclude);
            itemsCount += Words.Length;
        }

        if(IncludeSentences)
        {
            IEnumerable<string> sentencesToInclude = Sentences;

            if (CapitalizeWords)
            {
                sentencesToInclude = sentencesToInclude.Select(s => s.ToUpper());
            }

            texts = texts.Concat(sentencesToInclude);
            itemsCount += Sentences.Length;
        }

        if(itemsCount == 0)
        {
            CurrentText = null!;
        }
        else
        {
            int randomIndex = Random.Shared.Next(itemsCount);
            CurrentText = texts.ElementAt(randomIndex);
        }
    }

    private string[] CapitalLetters { get; } = ["А", "Б", "В", "Г", "Д", "Е", "Ж", "З", "И", "Й", "К", "Л", "М", "Н", "О", "П", "Р", "С", "Т", "У", "Ф", "Х", "Ц", "Ч", "Ш", "Щ", "Ъ", "Ю", "Я"];
    private string[] SmallLetters { get; } = ["а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п", "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"];
    private string[] LetterPairs { get; } = ["Аа", "Бб", "Вв", "Гг", "Дд", "Ее", "Жж", "Зз", "Ии", "Йй", "Кк", "Лл", "Мм", "Нн", "Оо", "Пп", "Рр", "Сс", "Тт", "Уу", "Фф", "Хх", "Цц", "Чч", "Шш", "Щщ", "Ъъ", "ь", "Юю", "Яя"];
    private string[] Words { get; } =
    [
        "баба", "дядо", "татко", "мама", "кака", "чичо", "леля", "топка", "котка", "куче", "кон", "риба", "пате", "прасе", "вода",
        "сок", "хляб", "песен", "баня", "вана", "език", "пръст", "къща", "таван", "ряпа", "домат", "ябълка", "круша", "банан",
        "чаша", "нож", "яке", "елен", "сърна", "муха", "бор", "пор", "тор", "ток", "сом", "фон", "тон", "град", "село", "рог", "едно",
        "еднорог", "сам", "бар", "маса", "поток", "лимон", "перде", "сняг", "кола", "лов", "пън", "рак", "мир", "нос", "кал", "боб"
    ];
    private string[] Sentences { get; } =
    [
        "Тати яде цаца",
        "Дядо вади ряпа",
        "Мама пие вода",
        "Баба меси питка",
        "Кака ходи боса",
        "Мечо Пух яде мед",
        "Ще ям месо",
        "Пиле Миле ходи босо",
        "Лоша кака бие бебе",
        "Добра кака пази бебе",
        "Мама печели пари",
        "Боли ме зъб",
        "Кака обича розови понита",
        "Мама се кара на тати",
        "Тати се кара на кака",
        "Кака се кара на бебето",
        "Кака се къпе в банята",
        "Дядо гони пони",
        "Тати ходи бос",
        "Аз съм дете",
        "Аз съм весела",
        "Ще ям баница",
        "Мама яде баница",
        "Баба гони муха",
        "Дай ми вода",
        "Ще ям супа",
        "Чичо носи синя риза",
        "Кака се къпе в зелена вана",
        "Мама счупи чаша",
        "Дядо си купи бяла риза",
        "Момиче шие с игла",
        "Еднорог тича сам в гората",
        "Вълк гони еднорог",
        "Момиче храни еднорог",
        "Аз съм прасе",
        "Аз ям мусака"
    ];
}