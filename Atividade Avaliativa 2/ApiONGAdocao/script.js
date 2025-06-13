const API_URL = "http://localhost:5199/api/animais";

document.getElementById("form-adicionar").addEventListener("submit", async (e) => {
  e.preventDefault();

  const animal = {
    nome: document.getElementById("nome").value,
    especie: document.getElementById("especie").value,
    raca: document.getElementById("raca").value,
    idade: parseInt(document.getElementById("idade").value),
    peso: parseFloat(document.getElementById("peso").value)
  };

  const res = await fetch(API_URL, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(animal),
  });

  if (res.ok) {
    alert("Animal adicionado com sucesso!");
    listarAnimais();
    e.target.reset();
  } else {
    alert("Erro ao adicionar animal.");
  }
});

// async function listarAnimais() {
//   const res = await fetch(API_URL);
//   const animais = await res.json();
//   const lista = document.getElementById("lista-animais");
//   lista.innerHTML = "";

//   animais.forEach((animal) => {
//     const li = document.createElement("li");
//     li.textContent = `ID: ${animal.id} | Nome: ${animal.nome} | Espécie: ${animal.especie} | Raça: ${animal.raca} | Idade: ${animal.idade} | Peso: ${animal.peso} kg`;
//     lista.appendChild(li);
//   });
// }

// async function buscarAnimal() {
//   const id = document.getElementById("buscar-id").value;
//   const res = await fetch(`${API_URL}/${id}`);
//   const div = document.getElementById("resultado-busca");

//   if (res.ok) {
//     const animal = await res.json();
//     div.textContent = `Nome: ${animal.nome}, Espécie: ${animal.especie}, Raça: ${animal.raca}, Idade: ${animal.idade}, Peso: ${animal.peso} kg`;
//   } else {
//     div.textContent = "Animal não encontrado.";
//   }
// }

function listarAnimais() {
  fetch(API_URL)
    .then(response => response.json())
    .then(animais => {
      const lista = document.getElementById("lista-animais");
      lista.innerHTML = "";

      animais.forEach(animal => {
        const data = new Date(animal.dataCadastro);
        const dataFormatada = data.toLocaleDateString("pt-BR");

        const li = document.createElement("li");
        li.innerHTML = `
          <strong>ID: ${animal.id}</strong><br>
          Nome: ${animal.nome} (${animal.especie} - ${animal.raca})<br>
          Idade: ${animal.idade} anos - Peso: ${animal.peso} kg<br>
          <em>Cadastrado em: ${dataFormatada}</em>
          <hr>
        `;
        lista.appendChild(li);
      });
    });
}

function buscarPorId() {
  const id = document.getElementById("buscar-id").value;
  if (!id) {
    alert("Informe um ID");
    return;
  }

  fetch(`${API_URL}/${id}`)
    .then(response => {
      if (!response.ok) throw new Error("Animal não encontrado.");
      return response.json();
    })
    .then(animal => {
      const data = new Date(animal.dataCadastro);
      const dataFormatada = data.toLocaleDateString("pt-BR");

      const div = document.getElementById("resultado-busca");
      div.innerHTML = `
        <h3>ID: ${animal.id} - ${animal.nome}</h3>
        <p>Espécie: ${animal.especie}</p>
        <p>Raça: ${animal.raca}</p>
        <p>Idade: ${animal.idade} anos</p>
        <p>Peso: ${animal.peso} kg</p>
        <p><em>Cadastrado em: ${dataFormatada}</em></p>
        <hr>
      `;
    })
    .catch(error => {
      document.getElementById("resultado-busca").innerHTML = `<p>${error.message}</p>`;
    });
}

async function excluirAnimal() {
  const id = document.getElementById("excluir-id").value;
  const res = await fetch(`${API_URL}/${id}`, {
    method: "DELETE",
  });

  if (res.ok) {
    alert("Animal excluído com sucesso!");
    listarAnimais();
  } else {
    alert("Erro ao excluir animal.");
  }
}

document.getElementById("form-editar").addEventListener("submit", async (e) => {
  e.preventDefault();

  const id = document.getElementById("editar-id").value;

  const animalEditado = {
    nome: document.getElementById("editar-nome").value,
    especie: document.getElementById("editar-especie").value,
    raca: document.getElementById("editar-raca").value,
    idade: parseInt(document.getElementById("editar-idade").value),
    peso: parseFloat(document.getElementById("editar-peso").value)
  };

  const res = await fetch(`${API_URL}/${id}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(animalEditado),
  });

  if (res.ok) {
    alert("Animal atualizado com sucesso!");
    listarAnimais();
    e.target.reset();
  } else {
    alert("Erro ao atualizar animal. Verifique o ID.");
  }
});

document.getElementById("btn-calcular").addEventListener("click", () => {
  const idade = parseInt(document.getElementById("idade").value);
  const peso = parseFloat(document.getElementById("peso").value);

  if (isNaN(idade) || isNaN(peso)) {
    alert("Preencha os campos de idade e peso corretamente.");
    return;
  }

  const resultado = idade * peso;
  
  window.location.href = `resultado.html?resultado=${resultado}`;
});