# Programa de Gestion de empleados

## Integrantes del equipo:
* Escobar Ortega Emmanuel Alexander Carnet: EO260404
* Cosme Palacios Pedro Aristides Carnet: CP240499
* Guerrero Polaco, Jose Manuel Carnet: GP170487
* Quintanilla Avalos Fernando Josue Carnet: QA221370

## Programado en

*   **Lenguaje:** C# 
*   **Desarrollado:** Visual Studio Comunity

## Descripcion del proyecto
* Este programa es una aplicación de consola en C# diseñada para la gestión integral de empleados dentro de una empresa, dicha aplicacion permite registrar diferentes tipos de trabajadores (asalariados, por hora y comisionistas), calcular sus salarios de formas dinámicas mediante el uso de herencia, así como buscar, listar y eliminar empleados garantizando la validación de datos y el control de excepciones personalizadas.

## Diagrama UML:

<img width="1409" height="734" alt="Sistema de Gestión de Empleados UML" src="https://github.com/user-attachments/assets/34f677e5-9229-45d0-97e1-8156b6e11036" />

---
## Explicación de la Jerarquía de Clases y Herencia

El proyecto aplica los principios de la Programación Orientada a Objetos (POO) mediante una estructura jerárquica basada en herencia y polimorfismo:

* **Clase Base Abstracta (`Empleado`):**
  Define los atributos generales (`Nombre` e `Id`) y el método abstracto `CalcularSalario()`, obligando a las clases hijas a definir su propio cálculo.

* **Clases Derivadas (Herencia):**
  * **`EmpleadoAsalariado`:** Implementa `CalcularSalario()` usando su `SueldoMensualFijo`.
  * **`EmpleadoPorHora`:** Calcula el sueldo multiplicando `SueldoPorHora * HorasTrabajadas`.
  * **`EmpleadoComisionista`:** Suma su `SueldoBase` más la comisión de sus ventas (`VentasRealizadas * PorcentajeComision`).

* **Polimorfismo:**
  Permite almacenar todas las variantes dentro de una lista unificada `List<Empleado>` y ejecutar el cálculo de salario e impresión (`ToString()`) de forma automática según el tipo de empleado.

## Instrucciones de Ejecución

### Requisitos
* **Visual Studio Comunity**.

---

### 1. Descargar el proyecto
Clona el repositorio o descarga el código fuente y sus respectivas clases

### 2.Ingresarlos en la carpeta del proyecto

### 3.Ejecutar el archivo del proyecto

---

### Evidencias
<img width="959" height="473" alt="Captura de pantalla 2026-07-27 171727" src="https://github.com/user-attachments/assets/4a8798b8-8505-495c-8151-524fef3bfb5e" />
<img width="956" height="477" alt="Captura de pantalla 2026-07-27 171936" src="https://github.com/user-attachments/assets/b81481c1-9c56-4950-ad6f-0c0e08b32638" />
<img width="960" height="475" alt="Captura de pantalla 2026-07-27 171854" src="https://github.com/user-attachments/assets/905ec037-c923-46d5-8802-9f20be1890e9" />
<img width="958" height="475" alt="Captura de pantalla 2026-07-27 171802" src="https://github.com/user-attachments/assets/0b33c7fd-240a-4a24-a30b-8c354bc142e2" />
<img width="961" height="480" alt="Captura de pantalla 2026-07-27 171709" src="https://github.com/user-attachments/assets/e55cbb82-e67a-4da8-982d-a76ba19075be" />

  
