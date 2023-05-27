
INSERT INTO Receita(ReceitaId, Name,Description,Instructions)
VALUES
    (NEWID(),'Bacalhau a Bras','Bacalhau a Bras','Enrolar o Bacalhau e por no Forno'),
    (NEWID(),'Frango Assado','Frango Assado','Acender o lume a assar o frango'),
    (NEWID(),'Sopa de Legumes','Sopa de Legumes','Uma panela ao lume com agua, cortar os legumes'),
    (NEWID(),'Cabrito no Forno','Cabrito no Forno','Por o cabrito no forno a 500 graus')

INSERT INTO ReceitaItem(ReceitaItemId, Descricao)
VALUES
    (NEWID(), 0),
    (NEWID(), 'Dieta Vegan'),
    (NEWID(), 'Dieta Vegeteriano'),
    (NEWID(), 'Dieta vermelho')

    INSERT INTO ReceitaItem(ReceitaItemId, UnitOfMeasure,IngredienteId,ReceitaId,Qty)
VALUES
    (NEWID(), 1,'7f9a0d6a-31ac-4845-bbe3-f6ef9fe4f2c4','677ec28a-3d7f-4258-8b16-dd22963f1e47',500),
    (NEWID(), 2,'ad40cfd0-a6e1-463b-93bf-eedd553797d2','677ec28a-3d7f-4258-8b16-dd22963f1e47',1)



        INSERT INTO ItemPlanoAlimentacao(MealPlanItemId, MealType,ReceitaId,Date,PlanoAlimentacaoIdPlanoAlimentacao)
VALUES
    (NEWID(), 3,'677ec28a-3d7f-4258-8b16-dd22963f1e47',GETDATE(),2),








