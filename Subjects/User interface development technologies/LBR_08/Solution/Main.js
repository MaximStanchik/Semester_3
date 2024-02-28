let user = {
    name: 'Masha',
    age: 21
};

let numbers = [1, 2, 3];

let user1 = {
    name: 'Masha',
    age: 23,
    location: {
        city: 'Minsk',
        country: 'Belarus'
    }
};

let user2 = {
    name: 'Masha',
    age: 28, 
    skills: ["HTML", "CSS", "JavaScript", "React"]
};

const array = [
    {id: 1, name: 'Vasya', group: 10},
    {id: 2, name: 'Ivan', group: 11},
    {id: 3, name: 'Masha', group: 12},
    {id: 4, name: 'Petya', group: 10},
    {id: 5, name: 'Kira', group: 11},
]

let user4 = {
    name: 'Masha',
    age:19,
    studies: {
        university: 'BSTU',
        speciality: 'designer',
        year: 2020,
        exams: {
            maths: true,
            programming: false
        }
    }
};

let user5 = {
    name: 'Masha',
    age: 22,
    studies: {
      university: 'BSTU',
      speciality: 'designer',
      year: 2020,
      department: {
        faculty: 'FIT',
        group: 10,
      },
      exams: [
        {subject: 'maths', mark: 8},
        {subject: 'programming', mark: 4},
      ]
    }
  };

  let user6 = {
    name: 'Masha',
    age: 21,
    studies: {
      university: 'BSTU',
      speciality: 'designer',
      year: 2020,
      department: {
        faculty: 'FIT',
        group: 10,
      },
      exams: [
        {
          subject: 'maths',
          mark: 8,
          professor: {
            name: 'Ivan Ivanov',
            degree: 'PhD'
          }
        },
        {
          subject: 'programming',
          mark: 10,
          professor: {
            name: 'Petr Petrov',
            degree: 'PhD'
          }
        },
      ]
    }
  };

  let user7 = {
    name: 'Masha',
    age: 20,
    studies: {
      university: 'BSTU',
      speciality: 'designer',
      year: 2020,
      department: {
        faculty: 'FIT',
        group: 10,
      },
      exams: [
        {
          subject: 'maths',
          mark: 8,
          professor: {
            name: 'Ivan Ivanov',
            degree: 'PhD',
            articles: [
              {title: "About HTML", pagesNumber: 3},
              {title: "About CSS", pagesNumber: 5},
              {title: "About JavaScript", pagesNumber: 1},
            ]
          }
        },
        {
          subject: 'programming',
          mark: 10,
          professor: {
            name: 'Petr Petrov',
            degree: 'PhD',
            articles: [
              {title: "About HTML", pagesNumber: 3},
              {title: "About CSS", pagesNumber: 5},
              {title: "About JavaScript", pagesNumber: 1},
            ]
          }
        }
      ]
    }
  };

  let store = {
    state: { // 1 уровень
        profilePage: { // 2 уровень
            posts: [ // 3 уровень
            {id: 1, message: 'Hi', likesCount: 12},
            {id: 2, message: 'By', likesCount: 1},
            ],
            newPostText: 'About me',
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
    },
  }


  //Выволнение первого задания:

let userCopy    = { ...user };
let numbersCopy = [ ...numbers ];
let user1Copy   = { ...user1 };
let user2Copy   = { ...user2 };
let arrayCopy   = [ ...array ];
let user4Copy   = { ...user4 };
let user5Copy   = { ...user5 };
let user6Copy   = { ...user6 };
let user7Copy   = { ...user7 };

let storeCopy = {
  state: {
    ...store.state,
    profilePage: {
      ...store.state.profilePage,
      posts: [ ...store.state.profilePage.posts ],
    },
    dialogsPage: {
      ...store.state.dialogsPage,
      dialogs: [ ...store.state.dialogsPage.dialogs ],
      messages: [ ...store.state.dialogsPage.messages ],
    },
  },
};

//Выполнение второго задания:

user5Copy.studies.department.group = 12;

user5Copy.studies.exams.find((exam) => exam.subject === 'programming').mark = 10;

alert(user5Copy.studies.exams[1].mark);
//Выполнение третьего задания:

user6Copy.studies.exams.find((exam) => exam.subject === 'programming').professor.name = 'Nikolay Beloded';

//Выполнение четвертого задания:

const petrIvanov = user7Copy.studies.exams.find((exam) => exam.professor.name === 'Petr Ivanov');

const aboutCssArticle = petrIvanov.articles.find((article) => article.title === 'About CSS');

aboutCssArticle.pagesNumber = 3;

//Выполнение пятого задания:

store.state.dialogsPage.messages.forEach((message) => {
  message.message = 'Hello';
});