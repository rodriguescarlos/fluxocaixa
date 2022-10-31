SELECT		CONVERT(VARCHAR(10), DataMovimento, 121) DATAMOVIMENTO,
			SUM(CASE WHEN LANC.TipoDC='D' THEN VALOR ELSE 0 END) DEBITO,
			SUM(CASE WHEN LANC.TIPODC='C' THEN VALOR ELSE 0 END) CREDITO,
			ABS(SUM(CASE WHEN LANC.TIPODC='D' THEN  VALOR * -1 ELSE VALOR END)) SALDO,
			CASE WHEN (SUM(CASE WHEN LANC.TIPODC='D' THEN  VALOR * -1 ELSE VALOR END) < 0) THEN 'D' ELSE 'C' END TIPODC
FROM		Movimento MOV
INNER JOIN	Lancamento LANC
ON			MOV.LancamentoId = LANC.Identificador
GROUP BY	TipoDC
			,CONVERT(VARCHAR(10), DataMovimento, 121)




