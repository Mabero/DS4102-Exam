<template>
  <form class="payment">
    <section class="card payment-section payment-person">
      <header>
        <h3>Personalia</h3>
      </header>

      <section class="name">
        <label>Navn</label>
        <input type="text" autocomplete="name" />
      </section>

      <section class="tlf">
        <label>Telefon</label>
        <input type="text" autocomplete="tel" />
      </section>

      <section class="address">
        <label>Adresse</label>
        <input type="text" autocomplete="street-address" />
      </section>

      <section class="postal-code">
        <label>Postnr.</label>
        <input type="text" autocomplete="postal-code" />
      </section>
    </section>

    <section class="card payment-section payment-card">
      <header>
        <h3>Kortinformasjon</h3>
      </header>

      <section class="cc-number">
        <label>Kortnummer</label>
        <input type="number" autocomplete="cc-number" />
      </section>

      <section class="cc-exp">
        <label>Gyldig til</label>
        <input type="month" autocomplete="cc-exp" />
      </section>

      <section class="cc-csc">
        <label>CVC</label>
        <input type="number" autocomplete="cc-csc" />
      </section>
    </section>

    <button @click="complete">Betal</button>
  </form>
</template>

<script>
import axios from "axios";
import { store } from "../../store.js";

export default {
  name: "Payment",
  methods: {
    complete(e) {
      e.preventDefault();
      if (document.cookie) {
        let cookies = document.cookie.split(";");
        if (cookies.length > 1) {
          return "";
        } else {
          let loginCookie = cookies[0].split("=");
          if (loginCookie[0] == "login") {
            let userID = loginCookie[1];
            let userDB = `https://localhost:5001/users/id/${userID}`;
            axios.get(userDB).then(response => {
              let order = {
                items: JSON.stringify(localStorage.getItem("order")),
                total: store.total(),
                useremail: response.data.email
              };
              console.log(order);
              let orderDB = `https://localhost:5001/orders`;
              axios.post(orderDB, order).then(() => {
                localStorage.removeItem("order");
                this.$router.push({ name: "FinishedOrder" });
              });
            });
          }
        }
      }
    }
  }
};
</script>

<style scoped>
.payment {
  display: grid;
  grid-template-columns: 1fr;
  gap: 20px;
}

.payment-section {
  padding: 20px;
  display: grid;
  grid-template-columns: repeat(7, 1fr);
  gap: 20px;
}

.payment-section header {
  grid-column: 1 / span 7;
}

.name,
.tlf,
.cc-number {
  grid-column: 1 / span 7;
}

.name,
.tlf,
.cc-number {
  grid-column: 1 / span 7;
}

.address,
.cc-exp {
  grid-column: span 4;
}

.postal-code,
.cc-csc {
  grid-column: span 3;
}

@media only screen and (min-width: 600px) {
  .name,
  .tlf,
  .cc-number {
    grid-column: 1 / span 7;
  }

  .address {
    grid-column: span 5;
  }

  .postal-code,
  .cc-exp,
  .cc-csc {
    grid-column: span 2;
  }
}
</style>