<template>
    <!-- BODY -->
    <div class="container-principal">
        <!-- HEADER -->
  
  
        <!-- MAIN -->
        <div class="container-meses">
            <div class="container-mes">
                <h3>ingresos </h3>
                <ul class="card-body">
                    <li v-for="(inc, index) in income" :key="index">
                        > $ {{ inc.value }} <button @click="removeBtnIncome(index)" class="btn-trash"> <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
  <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z"/>
  <path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"/>
  </svg></button>
                    </li>
                </ul>
                <p>TOTAL = $ {{ resultIncome }}</p>
                <form @submit.prevent="addBtnIncome" class=" flex-column">
                    <input v-model.number="newIncomeValue" placeholder="VALOR" type="number" step="0.01">
                    <button type="submit" class="btn-primary btn-card">Agregar</button>
                </form>
            </div>
            <hr>
            <div class="container-mes">
                <h3>gastos</h3>
                <ul class="card-body">
                    <li v-for="(exp, index) in expense" :key="exp.name">
                        > {{ exp.name }} : {{ exp.value }} <button @click="removeBtn(index)" class="btn-trash"><svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash" viewBox="0 0 16 16">
  <path d="M5.5 5.5A.5.5 0 0 1 6 6v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm2.5 0a.5.5 0 0 1 .5.5v6a.5.5 0 0 1-1 0V6a.5.5 0 0 1 .5-.5zm3 .5a.5.5 0 0 0-1 0v6a.5.5 0 0 0 1 0V6z"/>
  <path fill-rule="evenodd" d="M14.5 3a1 1 0 0 1-1 1H13v9a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2V4h-.5a1 1 0 0 1-1-1V2a1 1 0 0 1 1-1H6a1 1 0 0 1 1-1h2a1 1 0 0 1 1 1h3.5a1 1 0 0 1 1 1v1zM4.118 4 4 4.059V13a1 1 0 0 0 1 1h6a1 1 0 0 0 1-1V4.059L11.882 4H4.118zM2.5 3V2h11v1h-11z"/>
  </svg></button>
                    </li>
                </ul>
                <div class="container-datos">
                    <p :class="resultTotal ? 'positive' : 'negative'">TOTAL = $ {{ resultExpense }}</p>
                    <form @submit.prevent="addBtn" class=" flex-column">
                        <input v-model.trim="newExpenseName" placeholder="DESCRIPCION">
                        <input v-model.number="newExpenseValue" placeholder="VALOR" type="number" step="0.01">
                        <button type="submit" class="btn-primary btn-card">Agregar</button>
                    </form>
                </div>
            </div>
        </div>
    </div>
  </template>
  
  <!-- SCRIPT -->
  
  <script>
  export default {
    name: "Expenses",
    // COMPUTED
  
    computed: {
        expenseCount() {
            return this.expense.length;
        },
        incomeCount() {
            return this.income.length;
        },
        resultExpense() {
            this.total = 0;
            for (let i = 0; i < this.expense.length; i++) {
                this.total += this.expense[i].value;
            }
            return this.total
        },
        resultIncome() {
            this.total = 0;
            for (let i = 0; i < this.income.length; i++) {
                this.total += this.income[i].value;
            }
            return this.total
        },
        resultTotal() {
  
            this.flag = true;
            if (this.resultIncome >= this.resultExpense) {
                return this.flag
            } else {
                this.flag = false;
                return this.flag;
            }
        },
    },
  
    // METHODS
  
    methods: {
        addBtn() {
            if (this.newExpenseName != "" || this.newExpenseValue != 0 || this.newExpenseValue != "") {
                this.expense.push({ name: this.newExpenseName, value: this.newExpenseValue });
                this.newExpenseName = '', this.newExpenseValue = '';
            } else {
                alert("DEBE INGRESAR DATOS")
            }
        },
        removeBtn(index) {
            this.expense = this.expense.filter((exp, i) => i != index);
        },
        addBtnIncome() {
            this.income.push({ value: this.newIncomeValue });
            this.newIncomeValue = '';
        },
        removeBtnIncome(index) {
            this.income = this.income.filter((exp, i) => i != index);
        },
    },
  
    // DATA
  
    data() {
        return {
            newExpenseName: "",
            newExpenseValue: "",
            expense: [
                {
                    name: "ejemplo"
                    , value: 0
                },
            ],
            income: [{ value: 0 }],
            newIncomeValue: "",
            total: 0,
        }
    },
  
  }
  </script>
  
  <!-- // ESTILOS -->
  
  <style scoped>
  /* ESTILOS GENERALES */
  
  * {
    box-sizing: border-box;
    margin: 0;
    padding: 0;
    font-family: 'Roboto', sans-serif;
  
  }
  
  hr {
    margin: 1em;
  }
  
  .flex-column {
    display: flex;
    flex-direction: column;
    justify-content: center;
  }
  
  .container-principal {
    width: 90%;
    margin: 2em;
  }
  
  /* ESTILOS HEADER */
  
  .navbar {
    width: 100vw;
  
  }
  
  /* ESTILOS MAIN */
  
  .container-meses {
    background-color: rgb(228, 227, 227);
    border-radius: 1em;
    width: 33%;
    padding: 2em;
  }
  
  .container-mes {
    text-align: center;
    text-transform: uppercase;
    width: 100%;
    margin-bottom: 2em;
  }
  
  .container-mes p {
    margin: 1em auto;
    width: 90%;
    border-radius: 0.5em;
    font-weight: 700;
    background-color: rgb(201, 196, 196);
  
  }
  
  .container-mes ul {
    padding-left: 0;
  }
  
  .container-mes ul li {
    list-style: none;
  }
  
  .card-body {
    background-color: rgb(221, 221, 129);
    border-radius: 0.7em;
    margin: 2em 0;
    padding: 1em;
  
  }
  
  input {
    margin: 0.2em;
    border-radius: 0.5em;
    text-transform: uppercase;
    border: 2px solid black;
    padding: 0.3em;
  }
  
  .btn-card {
    margin: 0.2em;
    border-radius: 0.5em;
    background-color: black;
    color: white;
    border-style: solid;
    padding: 0.3em;
  }
  
  .btn-trash {
    margin-left: 3em;
    border: none;
    background-color: rgb(221, 221, 129);
    cursor: pointer;
  }
  
  .example {
    display: none;
  }
  
  .positive {
    color: green;
  }
  
  .negative {
    color: red;
  }
  </style>