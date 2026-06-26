# Contexto Geral - Flow Academy

## Objetivo do sistema

O Flow Academy e um sistema de gestao escolar dividido em dois modulos independentes:

- Desktop, feito em Windows Forms com C# e .NET Framework.
- Web, feito em PHP puro com HTML, CSS, Bootstrap e JavaScript.

Os dois modulos usam o mesmo banco de dados MySQL. Nao existe integracao direta entre o Desktop e o PHP. A integracao acontece somente pelo banco compartilhado.

## Prioridade atual

A prioridade atual do projeto e estabilizar o modulo Desktop, pois ele e o modulo administrativo principal. Depois disso o PHP deve ser revisado para garantir compatibilidade com o mesmo banco.

## Estrutura geral identificada

- Projeto C#: `FlowAcademy_cs`
- Classes C#: `FlowAcademy_cs/FlowAcademyClasses`
- Forms Desktop: `FlowAcademy_cs/FlowAcademy`
- PHP: `Flow-academy_Php/Flow-academy/web-php`
- Script SQL de referencia informado: `Atual.sql`
- Script de apoio ja existente no projeto: `procedures_para_Atual_conforme_CSharp.sql`

## Arquitetura geral

O Desktop segue o fluxo:

Forms

Classes

Banco

MySQL

As classes concentram regras e acesso ao banco. Os formularios controlam apenas a interface e consomem as classes.

O PHP usa SQL direto por meio de PDO e nao utiliza procedures.

## Estado geral

O projeto ja possui varias partes implementadas, mas ainda precisa de estabilizacao. Os principais pontos pendentes sao:

- Alinhar procedures do banco com as procedures chamadas pelo C#.
- Padronizar classes que ainda fogem do modelo definido.
- Revisar eventos de formularios que nao parecem conectados no Designer.
- Finalizar o `FrmPrincipal` como dashboard unico por perfil.
- Confirmar compatibilidade final entre C#, PHP e banco.
- Consolidar documentacao tecnica para apresentacao e manutencao.

