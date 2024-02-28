function sumValues(x, y, z) {
    return x + y + z;
}

function Main() {

    alert("Первое задание: есть массив цифр 1, 2, 3.");
    const numbersInFirstTask = [1, 2, 3];
    const [firstNumber, seconNumber, thirdNumber] = numbersInFirstTask;
    alert("Вывод результата выполнения первого задания: " + firstNumber);

    alert("Второе задание: объект admin содержит в себе все что есть в объекте user с помощью spread operator.");
    const user = {
        name: 'John',
        age: 30
    };
    
    const admin = {
        ...user
    };
    const result = `name: '${admin.name}', age: ${admin.age}`;
    user.name = 'Julia';
    alert("Вывод результата выполнения второго задания: " + result);

    alert("Третье задание: выполнить деструктуризацию объекта store до 3 уровня вложенности. После этого вывести значения likesCount из массива posts. Выполнить фильтрацию массива dialogs – выбрать пользователей с четными id.   В массиве messages заменить все сообщения на “Hello user” (использовать метод map).");
    
    let store = {
        state: { //1-ый уровень
            profilePage: { // 2-ой уровень
                posts: [ // 3-ий уровень
                    {id: 1, message: 'Hi', likesCount: 12},
                    {id: 2, message: 'By', likesCount: 1},
                ],
            newPostText: 'About me',
            },
        },
        dialogsPage: {
            dialogs: [
                {id: 1, name: 'Valera'},
                {id: 2, name: 'Andrey'},
                {id: 3, name: 'Sasha'},
                {id: 4, name: 'Viktor'},
            ],
            messages: [
                {id: 1, message: 'hi'},
                {id: 2, message: 'hi hi'},
                {id: 3, message: 'hi hi hi'},
            ],
        },
        sidebar: [],
    }

    const {
        state: {
          profilePage: { posts, newPostText },
        },
        dialogsPage: { dialogs, messages },
        sidebar,
      } = store;

    posts.forEach(post => {
        alert("Вывод значений likesCount из массива posts (жмите ОК чтобы продолжить вывод): " + post.likesCount);
    }); 

    alert("Пользователи с четными id: " + JSON.stringify(dialogs.filter(dialog => dialog.id % 2 === 0)));

    alert("Замененные сообщения в массиве messages на “Hello user”: " + JSON.stringify(messages.map(message => ({ id: message.id, message: 'Hello user' }))));

    alert("Четвертое задание: создать новую задачу task и добавить ее в массив, используя spread оператор");
    let tasks = [
        {id: 1, title: "HTML&CSS" , isDone: true },
        {id: 2, title: "JS"       , isDone: true },
        {id: 3, title: "ReactJS"  , isDone: false},
        {id: 4, title: "Rest API" , isDone: false},
        {id: 5, title: "GraphQL"  , isDone: false},
    ]
    let task = [
        {id: 6, title: "TS"  , isDone: false},
    ]
    tasks = [...tasks, ...task];
    alert("Вывод результата выполнения четвертого задания: " + JSON.stringify(tasks));

    alert("Пятое задание: массив [1, 2, 3] передется в качестве параметра функции sumValues с помощью spread operator.");
    const numbersInFifthTask = [1, 2, 3];
    alert("Вывод результата выполнения пятого задания: " + sumValues(...numbersInFifthTask));

}
Main();