using UnityEngine;

namespace HazarMath.Utils
{
    public static class MatrixMath
    {
#region Float Matrix

        public static float[,] Zeros(int rows, int cols) => new float[rows, cols];
        public static float[,] Ones(int rows, int cols)
        {
            float[,] result = new float[rows, cols];
            for (int i_row = 0; i_row < rows; i_row++)
            {
                for (int i_column = 0; i_column < cols; i_column++)
                {
                    result[i_row, i_column] = 1;
                }
            }

            return result;
        }
        public static float[,] Identity(int rows, int cols)
        {
            float[,] result = new float[rows, cols];
            for (int i_row = 0; i_row < rows; i_row++)
            {
                for (int i_column = 0; i_column < cols; i_column++)
                {
                    if (i_row == i_column)
                    {
                        result[i_row, i_column] = 1;
                    }
                    else
                    {
                        result[i_row, i_column] = 0;
                    }
                }
            }

            return result;
        }
        
        /// <summary>
        /// Sums two matrices (Matrixes must have the same dimensions) 
        /// </summary>
        public static float[,] SumMatrixes(float[,] matrixA, float[,] matrixB)
        {
            int aRowLength = matrixA.GetLength(0);
            int aColumnLength = matrixA.GetLength(1);
            int bRowLength = matrixB.GetLength(0);
            int bColumnLength = matrixB.GetLength(1);
            
            if (aRowLength != bRowLength || aColumnLength != bColumnLength)
            {
                Debug.LogError("Matrixes must have the same dimensions to be summed");
                return null;
            }

            var result = new float[aRowLength, aColumnLength];
            for (int i_row = 0; i_row < aRowLength; i_row++)
            {
                for (int i_column = 0; i_column < aColumnLength; i_column++)
                {
                    result[i_row, i_column] = matrixA[i_row, i_column] + matrixB[i_row, i_column];
                }
            }
            
            return result;
        }

        /// <summary>
        /// Subtracts two matrices (Matrixes must have the same dimensions)
        /// </summary>
        public static float[,] SubtractMatrixes(float[,] matrixA, float[,] matrixB)
        {
            int aRowLength = matrixA.GetLength(0);
            int aColumnLength = matrixA.GetLength(1);
            int bRowLength = matrixB.GetLength(0);
            int bColumnLength = matrixB.GetLength(1);
            
            if (aRowLength != bRowLength || aColumnLength != bColumnLength)
            {
                Debug.LogError("Matrixes must have the same dimensions to be subtracted");
                return null;
            }

            var result = new float[aRowLength, aColumnLength];
            for (int i_row = 0; i_row < aRowLength; i_row++)
            {
                for (int i_column = 0; i_column < aColumnLength; i_column++)
                {
                    result[i_row, i_column] = matrixA[i_row, i_column] - matrixB[i_row, i_column];
                }
            }
            
            return result;
        }
        
        public static float[,] MultiplyMatrix(float[,] matrix, float a)
        {
            var result = new float[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i_row = 0; i_row < matrix.GetLength(0); i_row++)
            {
                for (int i_column = 0; i_column < matrix.GetLength(1); i_column++)
                {
                    result[i_row, i_column] = matrix[i_row, i_column] * a;
                }
            }

            return result;
        }

        /// <summary>
        /// Multiplies two matrices (Matrix A rows must be equal to Matrix B columns)
        /// </summary>
        public static float[,] MultiplyMatrix(float[,] matrixA, float[,] matrixB)
        {
            int aRowLength = matrixA.GetLength(0);
            int aColumnLength = matrixA.GetLength(1);
            int bRowLength = matrixB.GetLength(0);
            int bColumnLength = matrixB.GetLength(1);
            
            if (aColumnLength != bRowLength)
            {
                Debug.LogError("Matrix A column length must be equal to matrix B row length");
                return null;
            }
            
            var result = new float[aRowLength, bColumnLength];
            for (int i_row = 0; i_row < aRowLength; i_row++)
            {
                for (int i_column = 0; i_column < aColumnLength; i_column++)
                {
                    float sum = 0;
                    for (int i2_column = 0; i2_column < aColumnLength; i2_column++)
                    {
                        sum += matrixA[i_row, i2_column] * matrixB[i2_column, i_column];
                    }
                    result[i_row, i_column] = sum;
                }
            }

            return result;
        }

        public static float[,] TransposeMatrix(float[,] matrix)
        {
            int rowLength = matrix.GetLength(0);
            int columnLength = matrix.GetLength(1);
            if (rowLength != columnLength)
            {
                Debug.LogError("Matrix must be rectangular");
                return null;
            }

            var result = new float[rowLength, columnLength];
            for (int i_row = 0; i_row < rowLength; i_row++)
            {
                for (int i_column = 0; i_column < columnLength; i_column++)
                {
                    result[i_column, i_row] = matrix[i_row, i_column];
                }
            }
            
            return result;
        }

        public static string MatrixToString(float[,] matrix)
        {
            string result = "";
            
            int rowLength = matrix.GetLength(0);
            int columnLength = matrix.GetLength(1);
            
            for (int i_row = 0; i_row < rowLength; i_row++)
            {
                for (int i_column = 0; i_column < columnLength; i_column++)
                {
                    result += $"{matrix[i_row, i_column]} ";
                }
                result += "\n";
            }

            return result;
        }
        
#endregion

#region Unity Matrix4x4

        public static Matrix4x4 Zeros4x4 => new Matrix4x4();
        public static Matrix4x4 Ones4x4 => new Matrix4x4(Vector4.one, Vector4.one, Vector4.one, Vector4.one);
        public static Matrix4x4 Identity4x4()
        {
            Matrix4x4 result = new Matrix4x4();
            result.SetRow(0, new Vector4(1, 0, 0, 0));
            result.SetRow(1, new Vector4(0, 1, 0, 0));
            result.SetRow(2, new Vector4(0, 0, 1, 0));
            result.SetRow(3, new Vector4(0, 0, 0, 1));
            return result;
        }

        public static Matrix4x4 SumMatrixes(Matrix4x4 matrixA, Matrix4x4 matrixB)
        {
            var result = new Matrix4x4();
            for (int i_row = 0; i_row < 4; i_row++)
            {
                for (int i_column = 0; i_column < 4; i_column++)
                {
                    result[i_row, i_column] = matrixA[i_row, i_column] + matrixB[i_row, i_column];
                }
            }
            
            return result;
        }
        
        public static Matrix4x4 SubtractMatrixes(Matrix4x4 matrixA, Matrix4x4 matrixB)
        {
            var result = new Matrix4x4();
            for (int i_row = 0; i_row < 4; i_row++)
            {
                for (int i_column = 0; i_column < 4; i_column++)
                {
                    result[i_row, i_column] = matrixA[i_row, i_column] - matrixB[i_row, i_column];
                }
            }
            
            return result;
        }
        
        public static Matrix4x4 MultiplyMatrix(Matrix4x4 matrix, float a)
        {
            var result = new Matrix4x4();
            for (int i_row = 0; i_row < 4; i_row++)
            {
                for (int i_column = 0; i_column < 4; i_column++)
                {
                    result[i_row, i_column] = matrix[i_row, i_column] * a;
                }
            }
            
            return result;
        }
        
        public static Matrix4x4 MultiplyMatrix(Matrix4x4 matrixA, Matrix4x4 matrixB)
        {
            var result = new Matrix4x4();
            for (int i_row = 0; i_row < 4; i_row++)
            {
                for (int i_column = 0; i_column < 4; i_column++)
                {
                    float sum = 0;
                    for (int i2_column = 0; i2_column < 4; i2_column++)
                    {
                        sum += matrixA[i_row, i2_column] * matrixB[i2_column, i_column];
                    }
                    result[i_row, i_column] = sum;
                }
            }
            
            return result;
        }
        
        public static Matrix4x4 TransposeMatrix(Matrix4x4 matrix)
        {
            var result = new Matrix4x4();
            for (int i_row = 0; i_row < 4; i_row++)
            {
                for (int i_column = 0; i_column < 4; i_column++)
                {
                    result[i_column, i_row] = matrix[i_row, i_column];
                }
            }
            
            return result;
        }
        
        public static string MatrixToString(Matrix4x4 matrix)
        {
            string result = "";
            for (int i_row = 0; i_row < 4; i_row++)
            {
                for (int i_column = 0; i_column < 4; i_column++)
                {
                    result += $"{matrix[i_row, i_column]} ";
                }
                result += "\n";
            }

            return result;
        }
#endregion
    }
}