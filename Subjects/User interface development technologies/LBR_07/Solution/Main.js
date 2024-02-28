let products = {
    Обувь: {
      Ботинки: [
        {
          номер: 1,
          размер: 42,
          цвет: "черный",
          цена: 2000
        },
        {
          номер: 2,
          размер: 39,
          цвет: "коричневый",
          цена: 1800
        }
      ],
      Кроссовки: [
        {
          номер: 3,
          размер: 40,
          цвет: "синий",
          цена: 2500
        },
        {
          номер: 4,
          размер: 38,
          цвет: "белый",
          цена: 2200
        }
      ],
      Сандалии: [
        {
          номер: 5,
          размер: 37,
          цвет: "красный",
          цена: 1500
        },
        {
          номер: 6,
          размер: 41,
          цвет: "желтый",
          цена: 1700
        }
      ]
    }
  };

  let newProducts = {
    Обувь: {
      Ботинки: [
        {
          номер: 1,
          размер: 42,
          цвет: "черный",
          стоимость: 2000,
          скидка: 0.1,
          get цена() {
            return this.стоимость * (1 - this.скидка);
          }
        },
        {
          номер: 2,
          размер: 39,
          цвет: "коричневый",
          стоимость: 1800,
          скидка: 0.05,
          get цена() {
            return this.стоимость * (1 - this.скидка);
          }
        }
      ],
      Кроссовки: [
        {
          номер: 3,
          размер: 40,
          цвет: "синий",
          стоимость: 2500,
          скидка: 0.2,
          get цена() {
            return this.стоимость * (1 - this.скидка);
          }
        },
        {
          номер: 4,
          размер: 38,
          цвет: "белый",
          стоимость: 2200,
          скидка: 0.15,
          get цена() {
            return this.стоимость * (1 - this.скидка);
          }
        }
      ],
      Сандалии: [
        {
          номер: 5,
          размер: 37,
          цвет: "красный",
          стоимость: 1500,
          скидка: 0.3,
          get цена() {
            return this.стоимость * (1 - this.скидка);
          }
        },
        {
          номер: 6,
          размер: 41,
          цвет: "желтый",
          стоимость: 1700,
          скидка: 0.1,
          get цена() {
            return this.стоимость * (1 - this.скидка);
          }
        }
      ]
    }
  };
  
  function filterShoes(minPrice, maxPrice, size, color) {
    let matchingProducts = [];
  
    for (let category in products.Обувь) {
      let shoes = products.Обувь[category];
  
      for (let i = 0; i < shoes.length; i++) {
        let shoe = shoes[i];
  
        if (
          shoe.цена >= minPrice &&
          shoe.цена <= maxPrice &&
          shoe.размер === size &&
          shoe.цвет.toLowerCase() === color.toLowerCase()
        ) {
          matchingProducts.push(shoe.номер);
        }
      }
    }
  
    if (matchingProducts.length > 0) {
      alert("Товары, соответствующие заданным условиям:\n" + matchingProducts.join(", "));
    } else {
      alert("Товары, соответствующие заданным условиям, не найдены.");
    }
  }
  
  Object.defineProperty(newProducts.Обувь.Ботинки[0], 'цена', {
    writable: true, 
    enumerable: true, 
    configurable: false 
  });
  
  Object.defineProperty(newProducts.Обувь.Ботинки[0], 'номер', {
    writable: false, 
    enumerable: true, 
    configurable: false 
  });

  class Shoe {
    constructor(номер, размер, цвет, стоимость, скидка) {
      this.номер = номер;
      this.размер = размер;
      this.цвет = цвет;
      this.стоимость = стоимость;
      this.скидка = скидка;
    }
  
    get цена() {
      return this.стоимость * (1 - this.скидка);
    }
  }
  
  class Boots extends Shoe {}
  class Sneakers extends Shoe {}
  class Sandals extends Shoe {}
  
  let moreNewProducts = {
    Обувь: {
      Ботинки: [
        new Boots(1, 42, "черный", 2000, 0.1),
        new Boots(2, 39, "коричневый", 1800, 0.05)
      ],
      Кроссовки: [
        new Sneakers(3, 40, "синий", 2500, 0.2),
        new Sneakers(4, 38, "белый", 2200, 0.15)
      ],
      Сандалии: [
        new Sandals(5, 37, "красный", 1500, 0.3),
        new Sandals(6, 41, "желтый", 1700, 0.1)
      ]
    }
};

  function Main() {
    alert("Идёт выполнение первой задачи...");
  
    let minPrice = parseFloat(prompt("Введите минимальную цену:"));
    let maxPrice = parseFloat(prompt("Введите максимальную цену:"));
    let size = parseInt(prompt("Введите размер обуви:"));
    let color = prompt("Введите цвет обуви:");
  
    filterShoes(minPrice, maxPrice, size, color);

    alert("Создана функция-фильтр для выполнения второго задания.");
    alert("Создан объект newProducts для выполнения третьего задания.");
    alert("Результат выполнения проверки изменения и перечисления свойств для четвертого задания выведен в консоль.");

    console.log(newProducts.Обувь.Ботинки[1].цена); 
    newProducts.Обувь.Ботинки[0].цена = 1500;      
    console.log(newProducts.Обувь.Ботинки[0].цена); 

    console.log(newProducts.Обувь.Ботинки[0].номер); 
    newProducts.Обувь.Ботинки[0].номер = 10;         
    console.log(newProducts.Обувь.Ботинки[0].номер);

    delete newProducts.Обувь.Ботинки[0].цена;        
    console.log(newProducts.Обувь.Ботинки[0].цена);  
  }
  
  Main();