using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Learning.CQRS.Infrastructure.Helper
{
    public class ObjectInvoker
    {
        public static object InvokeMethod(object o, string methodName, params object[] parameters)
        {
            string[] m = methodName.Split('.');
            for (int i = 0; i < m.Length - 1; i++)
                o = GetValue(o, m[i]);
            Type t = o.GetType();
            Type[] types = new Type[parameters.Length];
            for (int i = 0; i < parameters.Length; i++)
                types[i] = parameters[i] == null ? null : parameters[i].GetType();
            MethodInfo[] methods = t.GetMethods();
            foreach (MethodInfo mi in methods)
            {
                if (mi.Name == m[m.Length - 1])
                {
                    bool founded = true;
                    for (int i = 0; i < mi.GetParameters().Length; i++)
                    {
                        ParameterInfo pi = mi.GetParameters()[i];
                        if (pi.ParameterType.Name == "Object" || pi.ParameterType.Name == "Object&")
                            continue;
                        if (types[i] == null)
                            continue;
                        string p = pi.ParameterType.Name.TrimEnd('&');
                        if (p.ToLower() == "double" && types[i].Name.ToLower().Contains("int"))
                            continue;
                        if (p != types[i].Name)
                        {
                            founded = false;
                            break;
                        }
                    }
                    if (founded)
                        return mi.Invoke(o, parameters);
                }
            }
            throw new MethodAccessException();
        }
        public static object[] ConvertToObjectArray(IList data, string memberName)
        {
            object[] ret = new object[data.Count];
            if (data.Count == 0)
                return ret;
            Type t = data[0].GetType();
            int index = 0;
            if (memberName.Contains("."))
                foreach (object o in data)
                    ret[index++] = GetValue(t, o, memberName);
            else
            {
                string newMembername = memberName;
                object[] parameters = null;
                if (newMembername.Contains("("))
                {
                    int p1 = memberName.IndexOf("(");
                    int p2 = memberName.IndexOf(")");
                    if (p2 == -1)
                        return null;
                    string[] param = memberName.Substring(p1 + 1, p2 - p1 - 1).Split(',');
                    parameters = new object[param.Length];
                    for (int i = 0; i < param.Length; i++)
                        parameters[i] = param[i];
                    newMembername = memberName.Substring(0, p1);
                }

                PropertyInfo pi = t.GetProperty(newMembername);

                if (pi != null)
                    foreach (object o in data)
                        ret[index++] = GetPropertyValue(pi, o);
                else
                {
                    FieldInfo fi = t.GetField(newMembername);
                    if (fi != null)
                        foreach (object o in data)
                            ret[index++] = GetFeildValue(fi, o);
                    else
                    {
                        MethodInfo mi = t.GetMethod(newMembername);
                        if (mi != null)
                            foreach (object o in data)
                                ret[index++] = GetMethodValue(mi, o, parameters);
                    }
                }
            }
            return ret;
        }
        public static IList<object[]> ConvertToObjectArray(IList data, string[] members)
        {
            IList<object[]> ret = new List<object[]>();
            if (data.Count == 0)
                return ret;
            foreach (string s in members)
                ret.Add(ConvertToObjectArray(data, s));
            return ret;
        }
        public static object GetValue(object o, string memberName)
        {
            if (o == null)
                return null;
            Type t = o.GetType();
            return GetValue(t, o, memberName);
        }
        public static object GetValue(Type t, object o, string memberName)
        {
            string[] m = memberName.Split('.');
            foreach (string s in m)
            {
                string newS = s;
                object[] parameters = null;
                if (s.Contains("("))
                {
                    int p1 = s.IndexOf("(");
                    int p2 = s.IndexOf(")");
                    if (p2 == -1)
                        return null;
                    string[] param = s.Substring(p1 + 1, p2 - p1 - 1).Split(',');
                    parameters = new object[param.Length];
                    for (int i = 0; i < param.Length; i++)
                        parameters[i] = param[i];
                    newS = s.Substring(0, p1);
                }
                MemberInfo[] memInfos = t.GetMember(newS);
                if (memInfos.Length == 0)
                    return null;
                if (memInfos[0].MemberType == MemberTypes.Property)
                {
                    PropertyInfo pi = (PropertyInfo)memInfos[0];
                    o = GetPropertyValue(pi, o);
                    t = pi.PropertyType;
                }
                else if (memInfos[0].MemberType == MemberTypes.Field)
                {
                    FieldInfo fi = (FieldInfo)memInfos[0];
                    o = GetFeildValue(fi, o);
                    t = fi.FieldType;
                }
                else if (memInfos[0].MemberType == MemberTypes.Method)
                {
                    MethodInfo mi = (MethodInfo)memInfos[0];
                    o = GetMethodValue(mi, o, parameters);
                    t = mi.ReturnType;
                }
                else
                    return null;
            }
            return o;
        }
        public static object GetPropertyValue(PropertyInfo pi, object o)
        {
            if (o == null)
                return null;
            return pi.GetValue(o, new object[] { });
        }
        public static object GetMethodValue(MethodInfo mi, object o, object[] parametes)
        {
            if (o == null)
                return null;
            ParameterInfo[] pi = mi.GetParameters();
            if (pi.Length == 0)
                return mi.Invoke(o, new object[] { });
            else
            {
                for (int i = 0; i < pi.Length; i++)
                    parametes[i] = Convert.ChangeType(parametes[i], pi[i].ParameterType);
                return mi.Invoke(o, parametes);
            }
        }
        public static object GetFeildValue(FieldInfo fi, object o)
        {
            if (o == null)
                return null;
            return fi.GetValue(o);
        }
        public static void SetValue(object o, object val, string memberName)
        {
            if (o == null)
                throw new Exception("Object is null");
            string[] m = memberName.Split('.');
            for (int i = 0; i < m.Length - 1; i++)
            {
                o = GetValue(o, m[i]);
                if (o == null)
                    throw new Exception(m[i] + " in " + memberName + " is null");
            }
            memberName = m[m.Length - 1];

            Type t = o.GetType();
            FieldInfo fi = t.GetField(memberName);
            if (fi != null)
            {
                fi.SetValue(o, val);
            }
            else
            {
                PropertyInfo pi = t.GetProperty(memberName);
                if (pi != null)
                {
                    if (val is IList)
                    {
                        IList arr = (IList)pi.GetGetMethod().Invoke(o, new object[] { });
                        arr.Clear();
                        foreach (object o1 in (val as IList))
                            arr.Add(o1);
                    }
                    else
                        pi.GetSetMethod().Invoke(o, new object[] { val });
                }
                else
                {
                    throw new Exception("[" + memberName + "] not found in " + o.GetType().Name + " member list.");
                }
            }
        }
        public static Type GetType(Type baseType, string memberName)
        {
            string[] m = memberName.Split('.');
            foreach (string s in m)
            {
                PropertyInfo pi = baseType.GetProperty(s);
                if (pi != null)
                    baseType = pi.PropertyType;
                else
                {
                    FieldInfo fi = baseType.GetField(s);
                    if (fi != null)
                        baseType = fi.FieldType;
                    else
                    {
                        MethodInfo mi = baseType.GetMethod(s);
                        if (mi != null)
                            baseType = mi.ReturnType;
                        else
                            return null;
                    }
                }
            }
            return baseType;
        }

        public static object CreateDeepClone(object o)
        {
            if (o == null)
                return null;
            Type t = o.GetType();
            if (t.IsPrimitive)
                return o;
            if (t.IsEnum)
                return o;
            object c = null;
            MethodInfo cloneMethod = t.GetMethod("Clone");
            //MethodInfo[] mwe =  t.GetMethods();
            if (cloneMethod != null)
            {
                return cloneMethod.Invoke(o, new object[] { });
            }
            ConstructorInfo[] constructorInfos = t.GetConstructors();
            foreach (ConstructorInfo constructor in constructorInfos)
            {
                if (constructor.GetParameters().Length == 0)
                    c = constructor.Invoke(new object[] { });
            }
            if (c == null)
                throw new Exception("Cannot Create Clone, Empty Constructor Not Found");

            MemberInfo[] infos = t.GetMembers();

            foreach (MemberInfo info in infos)
            {
                Type memberType;
                if (info is FieldInfo)
                    memberType = (info as FieldInfo).FieldType;
                else if (info is PropertyInfo)
                {
                    memberType = (info as PropertyInfo).PropertyType;
                    if (!(info as PropertyInfo).CanWrite)
                        continue;
                }
                else
                    continue;


                if (memberType.IsPrimitive)
                {
                    CloneAttribute(info, o, c, false);
                    continue;
                }
                if (memberType.Equals(typeof(string)))
                {
                    CloneAttribute(info, o, c, false);
                    continue;
                }
                if (memberType.IsValueType)
                {
                    CloneAttribute(info, o, c, false);
                    continue;
                }
                if (memberType.IsGenericType)
                {
                    Type listType = memberType.GetGenericTypeDefinition();
                    if (listType.Equals(typeof(List<>)))
                        CloneList(info, o, c);
                    continue;
                }
                if (memberType.Equals(typeof(ArrayList)))
                {
                    CloneList(info, o, c);
                    continue;
                }
                if (memberType.IsClass)
                {
                    CloneAttribute(info, o, c, true);
                    continue;
                }
                throw new Exception("Cannot create Clone!");
            }

            return c;
        }
        private static void CloneList(MemberInfo info, object src, object dest)
        {
            IList srcList;
            IList destList;
            if (info is FieldInfo)
            {
                srcList = (info as FieldInfo).GetValue(src) as IList;
                ConstructorInfo cons = (info as FieldInfo).FieldType.GetConstructors()[0];
                destList = (IList)cons.Invoke(new object[] { });
            }
            else if (info is PropertyInfo)
            {
                srcList = (info as PropertyInfo).GetValue(src, null) as IList;
                ConstructorInfo cons = (info as PropertyInfo).PropertyType.GetConstructors()[0];
                destList = (IList)cons.Invoke(new object[] { });
            }
            else
                return;
            if (srcList == null)
                destList = null;
            else
            {
                foreach (object val in srcList)
                    destList.Add(CreateDeepClone(val));
            }
            if (info is FieldInfo)
                (info as FieldInfo).SetValue(dest, destList);
            else if (info is PropertyInfo)
                (info as PropertyInfo).SetValue(dest, destList, null);
        }
        private static void CloneAttribute(MemberInfo info, object src, object dest, bool createClone)
        {
            if (info is FieldInfo)
            {
                object val = (info as FieldInfo).GetValue(src);
                if (val != null && createClone)
                    val = CreateDeepClone(val);
                (info as FieldInfo).SetValue(dest, val);
            }
            else if (info is PropertyInfo)
            {
                object val = (info as PropertyInfo).GetValue(src, null);
                if (val != null && createClone)
                    val = CreateDeepClone(val);
                (info as PropertyInfo).SetValue(dest, val, null);
            }
        }
    }
}
