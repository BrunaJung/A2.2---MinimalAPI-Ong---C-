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

async function listarAnimais() {
  const res = await fetch(API_URL);
  const animais = await res.json();
  const lista = document.getElementById("lista-animais");
  lista.innerHTML = "";

  animais.forEach((animal) => {
    const li = document.createElement("li");
    li.textContent = `ID: ${animal.id} | Nome: ${animal.nome} | Espécie: ${animal.especie} | Raça: ${animal.raca} | Idade: ${animal.idade} | Peso: ${animal.peso} kg`;
    lista.appendChild(li);
  });
}

async function buscarAnimal() {
  const id = document.getElementById("buscar-id").value;
  const res = await fetch(`${API_URL}/${id}`);
  const div = document.getElementById("resultado-busca");

  if (res.ok) {
    const animal = await res.json();
    div.textContent = `Nome: ${animal.nome}, Espécie: ${animal.especie}, Raça: ${animal.raca}, Idade: ${animal.idade}, Peso: ${animal.peso} kg`;
  } else {
    div.textContent = "Animal não encontrado.";
  }
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