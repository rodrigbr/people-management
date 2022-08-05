export class SchoolingTypeStatic {
  id: string;
  name: string;

  constructor(id: string, name: string) {
      this.id = id;
      this.name = name;
  }

  public static Kindergarten = new SchoolingTypeStatic("25ea9187-4a1f-4b9f-b5a8-7aec8dc0f839", "Infantil");
  public static ElementarySchool = new SchoolingTypeStatic("8a2d312d-e804-4f51-934a-fc5634c1940a", "Fundamental");
  public static HighSchool = new SchoolingTypeStatic("0850abfa-209e-4c0e-b83f-34e62e492a89", "Médio");
  public static University = new SchoolingTypeStatic("f67a3dac-3365-4994-abb8-5a9059c4e58f", "Superior");

  public static GetAll(): Array<SchoolingTypeStatic> {
    let array: Array<SchoolingTypeStatic> = new Array<SchoolingTypeStatic>();
    array.push(this.Kindergarten);
    array.push(this.ElementarySchool);
    array.push(this.HighSchool);
    array.push(this.University);
    return array;
  }

  public static GetById(id: string): SchoolingTypeStatic {
    return this.GetAll().find(x => x.id.toLocaleLowerCase() === id.toLocaleLowerCase());
  }
}
